using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grow : MonoBehaviour
{

    // private bool grow = false;

    private Vector3 startingScale = new Vector3(0, -10, 0);
    private Vector3 endingScale = new Vector3(0, 0, 0);
    private float TotalTime = 3f;
    private float upTime;
    private float downTime;
    public float percentComplete = 0;

    // Update is called once per frame
    void Update()
    {

            if (LevelState.BossEvent)
            {
                // set up the lerp parameters
                upTime += Time.deltaTime;
                percentComplete = upTime / TotalTime;
                // apply the lerp over totalTime
                transform.localPosition = Vector3.Lerp(startingScale, endingScale, percentComplete);
            }
            else if (!LevelState.BossEvent && percentComplete != 0f)
            {
                downTime += Time.deltaTime;
                // revese the force field.
                percentComplete = downTime / TotalTime;
                transform.localPosition = Vector3.Lerp(endingScale, startingScale, percentComplete);

            }
    }
}


