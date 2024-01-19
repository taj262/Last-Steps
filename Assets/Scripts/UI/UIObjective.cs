using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIObjective : MonoBehaviour
{
    TMP_Text text;
    bool nextLevel = false;
    bool startTeleporter = false;
    int seconds = 5;
    // Start is called before the first frame update
    void Start()
    {
        startTeleporter = false;
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
            Invoke("setTeleporterEvent",3f);
            if(startTeleporter)
            {
                text.SetText("Defeat Boss");
            }
            else
            {
                text.SetText("Starting Teleporter");
            }

        }



    }
    void setTeleporterEvent()
    {
        
        startTeleporter = true;

    }
    void countDown()
    {
        if(seconds <= 0 )
        {
            text.SetText("Teleporting");
            Invoke("loadMenu",1f);
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
