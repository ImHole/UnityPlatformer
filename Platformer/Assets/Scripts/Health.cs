using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Health : MonoBehaviour
{
    public float HpMax = 100f;
    public float Hp = 0f;
    

    public Slider HpSlider;
    public TMP_Text HpText;

    void Start() {
        Hp = HpMax;
    }

    void Update() {

        float Value = Hp/HpMax;

        if(Input.GetKeyDown(KeyCode.H)){
            Hp -= 10f;
        }

        HpSlider.value = Value;
        HpText.text = "(" + Hp + "/"  + HpMax + ")";
    }
}
