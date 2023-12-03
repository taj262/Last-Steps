using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIObjective : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!LevelState.BossEvent && LevelState.Spawning)
        {
            text.SetText("Objective: Find Teleporter");
        }
        else if (LevelState.BossEvent)
        {
            text.SetText("Objective: Defeat Boss");

        }
        else
        {
            text.SetText("Objective: Survive");
        }
    }
}
