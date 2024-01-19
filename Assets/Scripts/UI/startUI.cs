using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class startUI : MonoBehaviour
{
    public TMP_Text startScreen;
    public static bool isLoading = false;
    // Start is called before the first frame update
    void Start()
    {
        isLoading = true;
        UIManager.isPaused = false;
        startScreen.enabled = false;
        Invoke("loadStart",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadStart()
    {
        
        startScreen.enabled = true;
        Invoke("disableStart",3f);   

    }
    void disableStart()
    {
        isLoading = false;
        gameObject.SetActive(false);
        


    }
}
