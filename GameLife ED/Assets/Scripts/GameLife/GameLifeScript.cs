using System.Collections;
using System.Collections.Generic;
using GameLife;
using UnityEngine;

public class GameLifeScript : MonoBehaviour {
    
    void Start() {

        var host = new DefaultPreset.Host(resizer.x, resizer.y, transform);
        
        gameHost_ = host.getHost();
    }

    void  FixedUpdate() {
        
        gameHost_.iteration();
    }
 
    public void updatePreset (int presetId) {

        gameHost_.updatePreset(presetId);
    }

    public void clickHandler (int x, int y) {

        gameHost_.clickHandler(x, y);
    }

    public void resizeField (int x, int y) {

        gameHost_.resizeField(x, y);
    }

    //---Class-Data---

    [SerializeField] private FieldResizer resizer;

    private GameLife.IHost gameHost_;
}
