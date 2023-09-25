using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletsPerSecond;
    bool canFire = true;

    public void FireBullet()
    {
        if (canFire)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            canFire = false;
            Invoke("EndFireCooldown", 1 / BulletsPerSecond);
        }
    }

    void EndFireCooldown()
    {
        canFire = true;
    }
}
