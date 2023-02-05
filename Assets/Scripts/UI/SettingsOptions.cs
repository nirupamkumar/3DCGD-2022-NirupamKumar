using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsOptions : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    private QualitySettings qualitySettings;
    
    void Start()
    {
        settingsMenu.SetActive(false);
        var qualityLevel = QualitySettings.GetQualityLevel();
        qualitySettings = GetComponent<QualitySettings>();
        QualitySettings.SetQualityLevel(2);
    }

    //Resolution settings
    public void ScreenResolution(int screenIndex)
    {
        switch(screenIndex)
        {
            case 0:
                Screen.SetResolution(680, 800, false);
                Debug.Log("800 x 680 resolution selected");
                break;
            case 1:
                Screen.SetResolution(1280, 780, true);
                Debug.Log("1280 x 780 resolution selected");
                break;
            case 2:
                Screen.SetResolution(1980, 1080, true);
                Debug.Log("1920 x 1080 resolution selected");
                break;

        }
    }

    //Game quality settings
    public void GameQuality(int qualityIndex)
    {
        switch(qualityIndex)
        {
            case 0:
                //low quality settings
                QualitySettings.SetQualityLevel(0, true);
                
                QualitySettings.pixelLightCount = 20;
                Debug.Log(QualitySettings.pixelLightCount);
                Debug.Log("Low setting selected");
                break;
            case 1:
                //Medium quality settings
                QualitySettings.SetQualityLevel(1, true);
                break;
            case 2:
                //High quality settings
                QualitySettings.SetQualityLevel(2, true);
                break;
        }
    }
    
}
