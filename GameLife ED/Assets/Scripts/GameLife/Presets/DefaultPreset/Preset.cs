using System;
using System.Security.Cryptography.X509Certificates;
using GameLife;
using UnityEngine;


namespace DefaultPreset {


public enum CellStates {

    Dead  = 0,
    Alive = 1,
}


class SimpleRules: IRules<CellStates> {

    public SimpleRules () {

        var decks = GameObject.FindGameObjectsWithTag("Deck");
        deck_ = decks[0].GetComponent<DefaultDeck.Deck>();
    }

    public CellStates nextStateOfCell (CellStates [,] input, int xCellCor, int yCellCor) {

        if (xCellCor < 0 || yCellCor < 0) {

            throw new System.Exception("Invalid coordinates of cell");
        }

        // int xSize = input.GetLength(0), ySize = input.GetLength(1);
        
        // int xStart = (xSize + xCellCor - 1) % xSize, yStart = (ySize + yCellCor - 1) % ySize;
        // int xEnd   =         (xCellCor + 2) % xSize, yEnd   =         (yCellCor + 2) % ySize;

        int numberOfNeighbours = 0;
        // for (int x = xStart; x != xEnd; x = (x + 1) % xSize) {

        //     for (int y = yStart; y != yEnd; y = (y + 1) % ySize) {

        //         if (x == xCellCor && y == yCellCor) {

        //             continue;
        //         }

        //         if (input[x, y] == CellStates.Alive) {

        //             ++numberOfNeighbours;
        //         }
        //     }
        // }

        for (int xOffset = -1; xOffset <= 1; ++xOffset) {

            for (int yOffset = -1; yOffset <= 1; ++yOffset) {

                if (xOffset == 0 && yOffset == 0) {

                    continue;
                }

                var coords = getCellByOffset(input, xCellCor, yCellCor, xOffset, yOffset);

                if (input[coords.Item1, coords.Item2] == CellStates.Alive) {

                    ++numberOfNeighbours;
                }
            }
        }

        CellStates cellState = input[xCellCor, yCellCor];

        if (numberOfNeighbours == 3 ||
            numberOfNeighbours == 2 && cellState == CellStates.Alive) {

            return CellStates.Alive;
        }
        
        return CellStates.Dead;
    }

    public void setDefaultField (CellStates [,] input) {

        if (input.GetLength(0) < 3 || input.GetLength(1) < 3) {

            Debug.Log("Imposseble to set default state of game due field size");
            return;
        }

        input[1, 0] = CellStates.Alive;
        input[2, 1] = CellStates.Alive;
        input[0, 2] = CellStates.Alive;
        input[1, 2] = CellStates.Alive;
        input[2, 2] = CellStates.Alive;
    }

    public void clickHandler (CellStates[,] field, int x, int y) {

        if (x >= field.GetLength(0) || y >= field.GetLength(1)) {

            throw new System.Exception("Invalid coordinates");
        }

        deck_.setGlider(field, x, y);
    }

    public static Tuple<int, int> getCellByOffset (CellStates [,] input, int x, int y, int xOffset, int yOffset) {

        if (x < 0 || y < 0) {

            throw new System.Exception("Invalid coordinates of cell");
        }

        int xSize = input.GetLength(0), ySize = input.GetLength(1);

        xOffset %= xSize;
        yOffset %= ySize;

        return new Tuple<int, int>((x + xSize - xOffset) % xSize, (y + ySize - yOffset) % ySize);
    }

    private DefaultDeck.Deck deck_;
}


public class Host: IHostGetter {

    public Host (int xFieldSize, int yFieldSize, Transform parentTransform) {

        Appearence<CellStates> appearnace = new Appearence<CellStates>("GameLifePresets/SimpleGame");
        SimpleRules            rules      = new SimpleRules();

        host_ = new GameHost<CellStates>(xFieldSize, yFieldSize, parentTransform, appearnace, rules);
    }

    public IHost getHost () {

        return host_;
    }

    private IHost host_;
}


}
