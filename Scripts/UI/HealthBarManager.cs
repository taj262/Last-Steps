using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    public GameObject player;
    private HealthComp hp;
    void Start()
    {
        hp = player.GetComponent<HealthComp>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hp.CurrentHealthPercent();
    }
}
