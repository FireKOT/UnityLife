using System;
using System.Collections.Generic;

using DefaultPreset;
using UnityEngine;


namespace DefaultDeck {

using Card = List<Tuple<int, int>>;


public class Deck: MonoBehaviour {

    public Deck () {

        glider_ = defineGlider();
    }

    public void setGlider (CellStates [,] input, int x, int y) {

        foreach (Tuple<int, int> pos in glider_) {

            var fieldPos = SimpleRules.getCellByOffset(input, x, y, pos.Item1, pos.Item2);

            input[fieldPos.Item1, fieldPos.Item2] = CellStates.Alive;
        }
    }

    public void rotateForeward () {

        Card tmp = new Card();

        foreach (Tuple<int, int> pos in glider_) {

            tmp.Add(Tuple.Create(pos.Item2, -pos.Item1));
        }

        glider_ = tmp;
    }

    public void rotateBackward () {

        Card tmp = new Card();

        foreach (Tuple<int, int> pos in glider_) {

            tmp.Add(Tuple.Create(-pos.Item2, pos.Item1));
        }

        glider_ = tmp;
    }

    private static Card defineGlider () {

        Card glider = new Card();

        glider.Add(Tuple.Create( 0,  1));
        glider.Add(Tuple.Create( 1,  0));
        glider.Add(Tuple.Create(-1, -1));
        glider.Add(Tuple.Create(-1,  0));
        glider.Add(Tuple.Create(-1,  1));

        return glider;
    }

    private Card glider_;
}


}
