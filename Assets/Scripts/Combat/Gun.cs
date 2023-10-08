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
            Quaternion bulletRotation = transform.rotation;
            bulletRotation.eulerAngles = new Vector3(0, bulletRotation.eulerAngles.y, 0); // Set Y rotation to parallel to xz plane
            Instantiate(Bullet, transform.position, bulletRotation);
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
