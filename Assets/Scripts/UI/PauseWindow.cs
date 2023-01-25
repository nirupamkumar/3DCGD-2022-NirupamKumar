using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    [SerializeField] private GameObject optionWindow;
    [SerializeField] private GameObject hudDisplay;

    private void Start()
    {
        optionWindow.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            optionWindow.SetActive(true);
            hudDisplay.SetActive(false);
        }
            
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        optionWindow.SetActive(false);
        hudDisplay.SetActive(true);
    }

    public void MainMenu()
    {
        Debug.Log("Main menu button clicked");
        SceneManager.LoadScene(0);
    }
}
