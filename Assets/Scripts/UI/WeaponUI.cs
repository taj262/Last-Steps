using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    TMP_Text text;
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch(WeaponEquiped.uiWeapon.gunType)
        {

            case GunType.shotgun:
            text.SetText("Shotgun");
            break;

            case GunType.rifle:
            text.SetText("Rifle");
            break;
            case GunType.pistol:
            text.SetText("Pistol");
            break;


        }   
    }
}
