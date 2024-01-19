using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public List<GameObject> restOfUI;
    public static bool isPaused = false;
    // Start is called before the first frame update
    void Awake()
    {
        isPaused = false;
        pauseUI.SetActive(isPaused);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && !startUI.isLoading)
        {
            pauseUI.SetActive(!isPaused);
            foreach( GameObject index in restOfUI )
            {
                index.SetActive(isPaused);
            }
            Time.timeScale = System.Convert.ToInt32(isPaused);
            isPaused = !isPaused;
            
        }
    }
}
