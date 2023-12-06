using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIObjective : MonoBehaviour
{
    TMP_Text text;
    bool nextLevel = false;
    int seconds = 5;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!LevelState.BossEvent && !LevelState.Spawning)
        {
            if(!nextLevel)
            {
                nextLevel = true;
                Invoke("countDown",1f);
            }
            return;
        }
        if(!LevelState.BossEvent && LevelState.Spawning)
        {
            text.SetText("Find Teleporter");
        }
         if (LevelState.BossEvent)
        {
            text.SetText("Defeat Boss");

        }



    }
    void countDown()
    {
        if(seconds <= 0 )
        {
            text.SetText("Teleporting");
            Invoke("loadMenu",2f);
            return;

        }
        text.SetText("Survive for "+seconds);
        seconds--;

        Invoke("countDown",1f);

    }
    void loadMenu()
    {
        Menu.loadNextScene();
    }
}
