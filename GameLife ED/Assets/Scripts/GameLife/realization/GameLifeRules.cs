namespace GameLife {


public interface IRules <CellStates> where CellStates : System.Enum {

    CellStates nextStateOfCell (CellStates [,] input, int xCellCor, int yCellCor);

    void setDefaultField (CellStates [,] input);

    void clickHandler (CellStates[,] field, int x, int y);
}


}