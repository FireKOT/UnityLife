using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldResizer : MonoBehaviour {

    void Awake () {

        x = defaultFieldXSize;
        y = defaultFieldYSize;

        defaultGameCameraPostion_ = new Vector3(gameCameraPosition.position.x, gameCameraPosition.position.y, gameCameraPosition.position.z);

        setGameCameraPosition();
    }

    public void resizeField (int xSize, int ySize) {

        x = xSize;
        y = ySize;

        setGameCameraPosition();

        game_.resizeField(x, y);
    }

    private void setGameCameraPosition () {

        gameCameraPosition.position = defaultGameCameraPostion_ + Vector3.right * x / 20;
    }

    [SerializeField] private GameLifeScript game_;

    [SerializeField] private int defaultFieldXSize;
    [SerializeField] private int defaultFieldYSize;

    public Transform gameCameraPosition;

    private Vector3 defaultGameCameraPostion_;

    public int x { get; private set; }
    public int y { get; private set; }
}
