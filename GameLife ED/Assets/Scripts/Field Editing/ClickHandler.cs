using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

    public void clickHandler (int x, int y) {

        host.clickHandler(x, y);
    }

    [SerializeField] GameLifeScript host;
}
