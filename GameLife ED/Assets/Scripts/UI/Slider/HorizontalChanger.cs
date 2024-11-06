using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalChanger : MonoBehaviour {

    void Start () {
        
        slider_.onValueChanged.AddListener(val => {

            sliderText_.text = val.ToString("0");

            resizer_.resizeField((int) val, resizer_.y);
        });
    }

    [SerializeField] private Slider slider_;
    [SerializeField] private TextMeshProUGUI sliderText_;
    [SerializeField] private FieldResizer resizer_;
}

