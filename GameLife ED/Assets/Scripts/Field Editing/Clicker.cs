using System.Collections;
using System.Collections.Generic;
using GameLife;
using UnityEngine;

public class Clicker : MonoBehaviour {

    void Start () {
        
        cellPosition_ = GetComponent<CellPosition>();
        
        var handlers = GameObject.FindGameObjectsWithTag("ClickHandler");
        handler_ = handlers[0].GetComponent<ClickHandler>();
    }

    void OnMouseUp () {

        handler_.clickHandler(cellPosition_.x, cellPosition_.y);
    }

    private CellPosition cellPosition_;
    private ClickHandler handler_;
}
