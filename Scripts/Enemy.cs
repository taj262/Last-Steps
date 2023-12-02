using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int MaxHealth;
    public int health { get; set; }

    Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().materials[0];
        health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        float healthPercentage = (float)health / (float)MaxHealth;

        Color color = Color.Lerp(Color.white, Color.red, 1 - healthPercentage);

        mat.color = color;
    }

}
