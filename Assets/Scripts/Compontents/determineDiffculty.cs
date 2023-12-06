using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class determineDiffculty : MonoBehaviour
{
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(SpawnerController.CAPACITY < 20 )
        {
            text.SetText("Baby");
        }
        else if(SpawnerController.CAPACITY >= 20 && SpawnerController.CAPACITY < 40 )
        {
            text.SetText("Easy");

        }
        else if (  SpawnerController.CAPACITY >= 40 && SpawnerController.CAPACITY < 60 )
        {
            text.SetText("Medium");

        }
        else if( SpawnerController.CAPACITY >= 60 && SpawnerController.CAPACITY < 80 )
        {
            text.SetText("Hard");
        }
        else
        {
            text.SetText("Insane");
        }

    }
}
