using System;
using System.Collections.Generic;
using UnityEngine;


namespace GameLife {


public class Appearence <CellStates> where CellStates : System.Enum {

    public Appearence (string presetPath) {

        var tileLoaders = GameObject.FindGameObjectsWithTag("TileLoader");
        loader_ = tileLoaders[0].GetComponent<TileLoader>();

        updatePreset(0);
    }

    public void updatePreset (int presetId) {

        if (presetId >= loader_.presets.Length) {

            throw new System.Exception("Invalid preset id");
        }

        tile_ = loader_.presets[presetId].tile;
        statesMaterials_ = loader_.presets[presetId].statesMaterials;
    }

    public GameObject getTile () {

        return tile_;
    }
 
    public Material[] getMaterialByCellState (CellStates cellState) {

        return statesMaterials_[cellState.ToString()];
    }

    //---Class-Data---

    private GameObject tile_;

    private Dictionary<string, Material[]> statesMaterials_;

    private TileLoader loader_;
}


}
