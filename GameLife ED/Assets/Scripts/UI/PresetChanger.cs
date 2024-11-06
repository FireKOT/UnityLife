using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetChanger : MonoBehaviour {

    void Start () {

        var tileLoaders = GameObject.FindGameObjectsWithTag("TileLoader");
        var loader = tileLoaders[0].GetComponent<TileLoader>();

        numberOfPresets = loader.presets.Length;
    } 

    public void setNextPreset () {

        currentPreset = (currentPreset + 1) % numberOfPresets;
        
        gameScript.updatePreset(currentPreset);
    }

    public void setPrevPreset () {

        currentPreset = (numberOfPresets + currentPreset - 1) % numberOfPresets;
        
        gameScript.updatePreset(currentPreset);
    }
 
    [SerializeField] GameLifeScript gameScript;
    
    public int numberOfPresets;
    public int currentPreset;
}
