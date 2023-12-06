using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    melee,
    shotgun,
    rifle,
    pistol
}

public enum FireType
{
    bolt, // has timer between fire
    semi, // fires once per click
    auto // auto fires when click is held down
}
[CreateAssetMenu(fileName = "GunObject", menuName = "ScpritableObjects/GunObject")]
public class GunScripableObject : ScriptableObject
{
    public string GunName;
    public string Description;

    public GunType gunType;
    public FireType fireType;

    public float FireRate;
    public float reloadRate;

    public GameObject GunModel;
    public GameObject MuzzleFlashPrefab;

    public GameObject Bullet;

}
