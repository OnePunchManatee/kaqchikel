using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EscapeMenu : MonoBehaviour
{

    public GameObject escapeMenu;
    public bool isPaused;
     
    // Start is called before the first frame update
    void Start()
    {
        escapeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        escapeMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        escapeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
