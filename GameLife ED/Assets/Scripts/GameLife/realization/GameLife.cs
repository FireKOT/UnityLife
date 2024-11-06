using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace GameLife {


public class Game <CellStates> where CellStates : System.Enum {

    public Game (int xFieldSize, int yFieldSize, GameLife.IRules<CellStates> rules) {

        rules_ = rules;

            gameState  = new CellStates[xFieldSize, yFieldSize];
        nextGameState_ = new CellStates[xFieldSize, yFieldSize];

        rules_.setDefaultField(gameState);
    }

    public void iteration () {

        gameLifeIterate(gameState, nextGameState_);

        (gameState, nextGameState_) = (nextGameState_, gameState);
    }

    private void gameLifeIterate (CellStates [,] field, CellStates [,] newState) {

        int xSize = field.GetLength(0), ySize = field.GetLength(1);

        if (xSize != newState.GetLength(0) || ySize != newState.GetLength(1)) {

            throw new System.Exception("Sizes of arrays are not the same");
        }

        for (int x = 0; x < xSize; ++x) {

            for (int y = 0; y < ySize; ++y) {

                newState[x, y] = rules_.nextStateOfCell(field, x, y);
            }
        }
    }

    public void clickHandler (int x, int y) {

        rules_.clickHandler(gameState, x, y);
    }

    public void resizeField (int x, int y) {

        if (x <= 0 || y <= 0) {

            throw new System.Exception("Invalid field size");
        }

        var tmp = new CellStates[x,y];
        int xOld = gameState.GetLength(0), yOld = gameState.GetLength(1);

        for (int xCor = 0; xCor < Math.Min(x, xOld); ++xCor) {

            for (int yCor = 0; yCor < Math.Min(y, yOld); ++yCor) {

                tmp[xCor, yCor] = gameState[xCor, yCor];
            }
        }

             gameState = tmp;
        nextGameState_ = new CellStates[x,y];
    }

    //---Class-Data---

    private GameLife.IRules<CellStates> rules_;

    public  CellStates[,] gameState;
    private CellStates[,] nextGameState_;
}


}