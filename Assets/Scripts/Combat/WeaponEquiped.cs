using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquiped : MonoBehaviour
{
    public GunScripableObject weapon;
    public static GunScripableObject uiWeapon;

    GameObject weaponModel;
    Transform grip;
    public static int ammo ;
    public static int maxAmmo;
    public static bool reloading;
    float reloadRate;
    void Awake()
    {
        switchGunType();
        reloading = false;
    }
    void Start()
    {
                // get the position of the grip
        switchGunType();

        
        weaponModel = Instantiate(weapon.GunModel, transform);
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyUp(KeyCode.Q) && !UIManager.isPaused)
        {
        switch(weapon.gunType)
        {

            case GunType.shotgun:
            weapon.gunType = GunType.rifle;
            break;

            case GunType.rifle:
            weapon.gunType = GunType.pistol;

            break;
            case GunType.pistol:
            weapon.gunType = GunType.shotgun;
            break;


        }
            switchGunType();

        }
        if((Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo )|| (reloading == false && ammo <=0))
        {
            Invoke("reload",reloadRate);
            reloading = true;
        }
    }
    public Transform MuzzleTransform;
    bool canFire = true;

    public void FireBullet()
    {
        if(UIManager.isPaused || startUI.isLoading ) canFire = false;

        if(reloading )return;

        
        if (canFire)
        {
            // fire melee
            if (weapon.gunType == GunType.melee)
            {

            }



            // fire shotgun
            if (weapon.gunType == GunType.shotgun)
            {
                // set bullet direction
                Quaternion bulletRotation = transform.rotation;
                bulletRotation.eulerAngles = new Vector3(0, bulletRotation.eulerAngles.y, 0); // Set Y rotation to parallel to xz plane

                // spawn shotgun bullets
                
                // fire rate will increase the amount of shots the shotgun shoots
                for (float shot = 0; shot <= 4f; shot++)
                {

                    // Apply random variation only to the x-axis
                    float randomY =  (shot * 10f) - 10f;
                    bulletRotation *= Quaternion.Euler(0f, randomY, 0f);

                    Instantiate(weapon.Bullet, weaponModel.transform.position, bulletRotation);
                }
            }



            // fire rifle
            if (weapon.gunType == GunType.rifle || weapon.gunType == GunType.pistol)
            {

                // set bullet direction
                Quaternion bulletRotation = transform.rotation;
                bulletRotation.eulerAngles = new Vector3(0, bulletRotation.eulerAngles.y, 0); // Set Y rotation to parallel to xz plane
                // spawn bullet
        
                Instantiate(weapon.Bullet, transform.position, bulletRotation);

                // spawn muzzel flash
                GameObject flash = Instantiate(weapon.MuzzleFlashPrefab, MuzzleTransform.position, MuzzleTransform.rotation);
                flash.transform.parent = transform;
                Destroy(flash, 0.25f);
            }


            // set can fire to off to prevent one shot per frame
            canFire = false;

            // if automatic is the fire type, call an invoke 
            if (weapon.fireType == FireType.auto)
            {
                Invoke("EndFireCooldown", 1 / weapon.FireRate);
            }

            // if fire type is semi auto, wait for "left mouse up" to renable can fire
            if (weapon.fireType == FireType.semi)
            {

            }
        }
    }
    void switchGunType()
    {
        
        switch(weapon.gunType)
        {
            case GunType.shotgun:
            weapon.fireType = FireType.semi;
            reloadRate = 3f;  
            maxAmmo = 2;
            break;
            case GunType.rifle:
            weapon.fireType = FireType.auto;
            reloadRate = 4.5f;
            maxAmmo = 20;
            break;
            case GunType.pistol:
            weapon.fireType = FireType.semi;
            reloadRate = 1f;
            maxAmmo = 12;
            break;


        }
        uiWeapon = weapon;
        ammo =  maxAmmo;
    }

    void reload()
    {
        reloading = false;
        ammo = maxAmmo;
    }

    public void EndFireCooldown()
    {
        if(UIManager.isPaused || startUI.isLoading)return;
        ammo--;
        canFire = true;
    }

}
