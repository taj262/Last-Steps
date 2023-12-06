using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    TMP_Text text;
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!WeaponEquiped.reloading)
        {
            text.SetText(WeaponEquiped.ammo + " / " + WeaponEquiped.maxAmmo );
        }
        else
        {
            text.SetText("Reloading");
        }
    }
}
