using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TilePreviever : MonoBehaviour {

    void Start() {
        
        var tileLoader = GameObject.FindGameObjectsWithTag("TileLoader")[0].GetComponent<TileLoader>();
        presets_ = tileLoader.presets;

        currentPresetId_ = 0;

        currentPreset_ = presets_[currentPresetId_];    //shit code but necessary for next line lazy to fix

        tilePreview_ = Instantiate(currentPreset_.tile, transform);
        tilePreviewRenderer_ = tilePreview_.GetComponent<Renderer>();

        tilePreview_.transform.eulerAngles = defaultRotationOfTile;

        setPreset(currentPresetId_);
    }

    void Update() {

        transform.Rotate(rotationSpeed * Time.deltaTime);

        switchUpdater();
    }

    public void setPreset (int presetId) {

        currentPreset_ = presets_[presetId];
        iter_ = currentPreset_.statesMaterials.Values.GetEnumerator();

        tilePreviewRenderer_.materials = nextStateOfTile();

        switchCounter_ = 0;
    }

    public void setNextPreset () {

        currentPresetId_ = (currentPresetId_ + 1) % presets_.Length;
        
        setPreset(currentPresetId_);
    }

    public void setPrevPreset () {

        currentPresetId_ = (presets_.Length + currentPresetId_ - 1) % presets_.Length;
        
        setPreset(currentPresetId_);
    }

    private void switchUpdater () {

        switchCounter_ += Time.deltaTime;
        if (switchCounter_ > switchTime) {

            switchCounter_ = 0;

            tilePreviewRenderer_.materials = nextStateOfTile();
        }
    }

    private Material[] nextStateOfTile () {

        if(!iter_.MoveNext()) {

            iter_ = currentPreset_.statesMaterials.Values.GetEnumerator();
            iter_.MoveNext();
        }

        return iter_.Current;
    }

    [SerializeField] private Vector3 defaultRotationOfTile;
    [SerializeField] private Vector3 rotationSpeed;
    [SerializeField] private float switchTime;

    private TilePreset[] presets_;

    private GameObject tilePreview_;
    private Renderer   tilePreviewRenderer_;

    private TilePreset currentPreset_;

    private Dictionary<string, Material[]>.ValueCollection.Enumerator iter_;

    private float switchCounter_ = 0;

    private int currentPresetId_;
}
