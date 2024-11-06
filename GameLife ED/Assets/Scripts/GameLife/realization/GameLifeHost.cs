using UnityEngine;


namespace GameLife {


public interface IHost {

    void iteration ();

    void updatePreset (int presetId);

    void clickHandler (int x, int y);

    void resizeField (int x, int y);
}


public interface IHostGetter {

    IHost getHost ();
}
    

public class GameHost <CellStates>: IHost where CellStates : System.Enum {

    public GameHost (int xFieldSize, int yFieldSize, Transform parentTransform, GameLife.Appearence<CellStates> appearence, GameLife.IRules<CellStates> rules) {
        
        viewer_ = new GameLife.Viewer<CellStates>(xFieldSize, yFieldSize, parentTransform, appearence);
        game_   = new GameLife.Game  <CellStates>(xFieldSize, yFieldSize, rules);
    }

    public void iteration () {

        viewer_.update(game_.gameState);

        game_.iteration();
    }

    public void updatePreset (int presetId) {

        viewer_.updatePreset(presetId);
    }

    public void clickHandler (int x, int y) {

        game_.clickHandler(x, y);
    }

    public void resizeField (int x, int y) {

        game_.resizeField (x, y);
        viewer_.resizeField(x, y);
    }

    //---Class-Data---

    private GameLife.Viewer<CellStates> viewer_;
    private GameLife.Game  <CellStates> game_;
}


}