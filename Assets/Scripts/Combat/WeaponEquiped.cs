using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquiped : MonoBehaviour
{
    public GunScripableObject weapon;

    GameObject weaponModel;
    Transform grip;
    
    
    void Start()
    {
        // get the position of the grip
        
        weaponModel = Instantiate(weapon.GunModel, transform);
    }

    public Transform MuzzleTransform;
    bool canFire = true;

    public void FireBullet()
    {
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
                for (float shot = 0; shot < weapon.FireRate; shot++)
                {

                    // Apply random variation only to the x-axis
                    float randomY = Random.Range(shot * -10f, shot * 10);
                    bulletRotation *= Quaternion.Euler(0f, randomY, 0f);

                    Instantiate(weapon.Bullet, weaponModel.transform.position, bulletRotation);
                }
            }



            // fire rifle
            if (weapon.gunType == GunType.rifle)
            {

                Debug.Log("Shot");
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
    


    public void EndFireCooldown()
    {
        canFire = true;
    }

}
