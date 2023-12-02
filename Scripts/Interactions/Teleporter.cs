using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Teleporter : MonoBehaviour, IInteractable
{
    
    
    // the displayed gameObject prompt
    public GameObject FloatingText;
    public GameObject LevelState;
    
    private bool untriggered = true;

    private void Start()
    {
        
    }

    // run when interacted with 
    public bool Interact(Interactor interactor)
    {
        // test to see if interacted with
        Debug.Log("Starting Teleporter");

        // remove prompt
        untriggered = false;
        RemovePrompt(this.GetComponent<Collider>());

        // change level state to boss mode
        LevelState.GetComponent<LevelState>().BossEvent = true;

        // return success
        return true;
    }



    // show the interact prompt
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && untriggered)
        {
            Debug.Log("inside");

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
        Instantiate(FloatingText, transform);
    }

}
