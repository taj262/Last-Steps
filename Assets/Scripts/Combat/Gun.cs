using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject MuzzleFlashPrefab;
    public Transform MuzzleTransform;
    public float BulletsPerSecond;
    bool canFire = true;

    public void FireBullet()
    {
        if (canFire)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            GameObject flash = Instantiate(MuzzleFlashPrefab, MuzzleTransform.position, MuzzleTransform.rotation);
            flash.transform.parent = transform;
            Destroy(flash, 0.25f);
            canFire = false;
            Invoke("EndFireCooldown", 1 / BulletsPerSecond);
        }
    }

    void EndFireCooldown()
    {
        canFire = true;
    }
}
