using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

// public class TileLoader : MonoBehaviour {

//     void Awake () {

//         string fullPath = Application.dataPath + "/Resources/GameLifePresets";
        
//         string[] folders = Directory.GetDirectories(fullPath);

//         presets = new TilePreset[folders.Length];

//         for (int i = 0; i < folders.Length; ++i) {

//             presets[i] = gameObject.AddComponent<TilePreset>();

//             string curPresetPath = "GameLifePresets/" + Path.GetFileName(folders[i]);

//             presets[i].tile = Resources.Load<GameObject>(curPresetPath + "/tile");
//             presets[i].statesMaterials = new Dictionary<string, Material[]>();    

//             string[] states = Directory.GetDirectories(folders[i]);

//             foreach (string state in states) {

//                 Debug.Log(curPresetPath + "/" + Path.GetFileName(state));

//                 var materials = Resources.LoadAll<Material>(curPresetPath + "/" + Path.GetFileName(state));
//                 presets[i].statesMaterials.Add(Path.GetFileName(state), materials);
//             }
//         }
//     }

//     public TilePreset[] presets;
// }

public class TileLoader : MonoBehaviour {

    void Awake () {

        int numberOfPresets = 4;

        presets = new TilePreset[numberOfPresets];
        for (int i = 0; i < numberOfPresets; ++i) {

            presets[i] = gameObject.AddComponent<TilePreset>();
            presets[i].statesMaterials = new Dictionary<string, Material[]>();
        }

        presets[0].tile = Resources.Load<GameObject>("GameLifePresets/0/tile");

        var materialsAlive0 = Resources.LoadAll<Material>("GameLifePresets/0/Alive");
        presets[0].statesMaterials.Add("Alive", materialsAlive0);

        var materialsDead0 = Resources.LoadAll<Material>("GameLifePresets/0/Dead");
        presets[0].statesMaterials.Add("Dead", materialsDead0);


        presets[1].tile = Resources.Load<GameObject>("GameLifePresets/1/tile");

        var materialsAlive1 = Resources.LoadAll<Material>("GameLifePresets/1/Alive");
        presets[1].statesMaterials.Add("Alive", materialsAlive1);

        var materialsDead1 = Resources.LoadAll<Material>("GameLifePresets/1/Dead");
        presets[1].statesMaterials.Add("Dead", materialsDead1);


        presets[2].tile = Resources.Load<GameObject>("GameLifePresets/2/tile");

        var materialsAlive2 = Resources.LoadAll<Material>("GameLifePresets/2/Alive");
        presets[2].statesMaterials.Add("Alive", materialsAlive2);

        var materialsDead2 = Resources.LoadAll<Material>("GameLifePresets/2/Dead");
        presets[2].statesMaterials.Add("Dead", materialsDead2);

        
        presets[3].tile = Resources.Load<GameObject>("GameLifePresets/3/tile");

        var materialsAlive3 = Resources.LoadAll<Material>("GameLifePresets/3/Alive");
        presets[3].statesMaterials.Add("Alive", materialsAlive3);

        var materialsDead3 = Resources.LoadAll<Material>("GameLifePresets/3/Dead");
        presets[3].statesMaterials.Add("Dead", materialsDead3);
    }

    public TilePreset[] presets;
}
