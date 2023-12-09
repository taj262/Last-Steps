using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Teleporter : MonoBehaviour, IInteractable
{
    
    
    // the displayed gameObject prompt
    public GameObject FloatingText;
    public GameObject Boss;
    public Transform player;
    
    private bool untriggered = true;

    private void Start()
    {
        
    }

    // run when interacted with 
    public bool Interact(Interactor interactor)
    {
        // test to see if interacted with

        // remove prompt
        untriggered = false;
        RemovePrompt(this.GetComponent<Collider>());

        // change level state to boss mode
        if(!LevelState.BossEvent)
        {
            LevelState.BossEvent = true;
            Invoke("spawnBoss",3f);
        }

        // return success
        return true;
    }
    void spawnBoss()
    {
        AI_MoveToGoal aiBoss = Boss.GetComponent<AI_MoveToGoal>();
        aiBoss.goal = player;
        Instantiate(Boss);
        Boss.transform.position = transform.position;

    }


    // show the interact prompt
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && untriggered)
        {

            ShowFloatingText();
        }
    }


    // remove the prompt when leaving
    private void OnTriggerExit(Collider other)
    {
        RemovePrompt(other);
    }

    void RemovePrompt(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            GameObject child = FindChildWithTag(this.gameObject, "FloatingText");
            Destroy(child);
        }
    }

    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }



    void ShowFloatingText()
    {
        Instantiate(FloatingText,transform);
    }

}
