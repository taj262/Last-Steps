using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactComp : MonoBehaviour, IReactToDamage
{
    Material mat;
    HealthComp currentHealth;
    public bool isBoss = false;
    private void Start()
    {
        currentHealth = GetComponent<HealthComp>();
        mat = GetComponent<MeshRenderer>().materials[0];
    }
    public void isHit() {
        Color color = Color.Lerp(Color.white, Color.red, 1 - currentHealth.CurrentHealthPercent());
        mat.color = color;
    }
    public void isDead() {
        if(isBoss)
        {
            LevelState.BossEvent = false;
            LevelState.Spawning =false;
        }
        else
        {
            SpawnerController.NUM_OF_ENEMIES--;
        }
        Destroy(gameObject);
    }
}
