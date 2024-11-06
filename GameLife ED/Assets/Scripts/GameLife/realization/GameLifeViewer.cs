using UnityEngine;


namespace GameLife {


public class Viewer <CellStates>: Object where CellStates : System.Enum {

    public Viewer (int xFieldSize, int yFieldSize, Transform parentTransform, GameLife.Appearence<CellStates> appearence) {

        parentTransform_ = parentTransform;

        appearence_ = appearence;

        setField(xFieldSize, yFieldSize);
    }

    public void update (CellStates[,] gameState) {
        
        int xLen = renderersOfField_.GetLength(0), yLen = renderersOfField_.GetLength(1);

        for (int x = 0; x < xLen; ++x) {

            for (int y = 0; y < yLen; ++y) {

                renderersOfField_[x, y].materials = appearence_.getMaterialByCellState(gameState[x, y]);
            }
        }
    }

    public void updatePreset (int presetId) {

        appearence_.updatePreset(presetId);
    }

    public void resizeField (int x, int y) {

        destroyField();

        setField(x, y);
    }

    private void setField (int xSize, int ySize) {

        if (xSize <= 0 || ySize <= 0) {

            throw new System.Exception("Invalid field size");
        }

        xFieldSize_ = xSize;
        yFieldSize_ = ySize;

        field_            = new GameObject[xFieldSize_, yFieldSize_];
        renderersOfField_ = new Renderer  [xFieldSize_, yFieldSize_];

        for (int x = 0; x < xFieldSize_; ++x) {

            for (int y = 0; y < yFieldSize_; ++y) {

                field_[x, y] = Instantiate(appearence_.getTile(), parentTransform_);

                var pos = field_[x, y].AddComponent<CellPosition>();
                pos.setPosition(x, y);

                field_[x, y].AddComponent<Clicker>();

                field_[x, y].transform.localPosition = new Vector3(x, 0, y);

                renderersOfField_[x, y] = field_[x, y].GetComponent<Renderer>();
            }
        }
    }

    private void destroyField () {

        for (int x = 0; x < xFieldSize_; ++x) {

            for (int y = 0; y < yFieldSize_; ++y) {

                Destroy(field_[x, y]);
            }
        }

        xFieldSize_ = 0;
        yFieldSize_ = 0;
    }

    //---Class-Data---

    private int xFieldSize_, yFieldSize_;

    private Transform parentTransform_;

    private GameLife.Appearence<CellStates> appearence_;

    private GameObject[,] field_;
    private   Renderer[,] renderersOfField_;
}


public class CellPosition: MonoBehaviour {

    public void setPosition (int xPos, int yPos) {

        x = xPos;
        y = yPos;
    }

    public int x, y;
}


}
