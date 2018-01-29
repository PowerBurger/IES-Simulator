using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public static int MotionBlur = 1;
    public GameObject MBon;
    public GameObject MBoff;
    public GameObject volumeOn;
    public GameObject volumeOff;

    void Start()
    {
        if (PlayerPrefs.GetInt("MotionBlur") == 0)
        {
            MBoff.SetActive(false);
            MBon.SetActive(true);
            print("MotionBlur is off");
        }

        if (PlayerPrefs.GetInt("MotionBlur") == 1)
        {
            MBoff.SetActive(true);
            MBon.SetActive(false);
            print("MotionBlur is on");
        }

        if (PlayerPrefs.GetInt("Volume") == 0)
        {
            volumeOff.SetActive(false);
            volumeOn.SetActive(true);
            AudioListener.pause = false;
        }

        if (PlayerPrefs.GetInt("Volume") == 1)
        {
            volumeOff.SetActive(true);
            volumeOn.SetActive(false);
            AudioListener.pause = true;
        }
    }
	
	void Update ()
    {
        MotionBlur = PlayerPrefs.GetInt("MotionBlur");
    }

    public void MotionBlurOn()
    {
        PlayerPrefs.SetInt("MotionBlur", 0);
        MBoff.SetActive(false);
        MBon.SetActive(true);
    }

    public void MotionBlurOff()
    {
        PlayerPrefs.SetInt("MotionBlur", 1);
        MBoff.SetActive(true);
        MBon.SetActive(false);
    }

    public void VolumeOn()
    {
        PlayerPrefs.SetInt("Volume", 0);
        volumeOff.SetActive(false);
        volumeOn.SetActive(true);
        AudioListener.pause = false;
    }

    public void VolumeOff()
    {
        PlayerPrefs.SetInt("Volume", 1);
        volumeOff.SetActive(true);
        volumeOn.SetActive(false);
        AudioListener.pause = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Back()
    {
        Application.LoadLevel("TitleScreen");
    }

    public void ShowGfx()
    {
        
    }

    public void HideGfx()
    {
       
    }

    public void Fantastic()
    {
        QualitySettings.currentLevel = QualityLevel.Fantastic;
        PlayerPrefs.SetString("GraphicsQuality", "Fantastic");
    }

    public void Beautiful()
    {
        QualitySettings.currentLevel = QualityLevel.Beautiful;
        PlayerPrefs.SetString("GraphicsQuality", "Beautiful");        
    }

    public void Good()
    {
        QualitySettings.currentLevel = QualityLevel.Good;
        PlayerPrefs.SetString("GraphicsQuality", "Good");        
    }

    public void Simple()
    {
        QualitySettings.currentLevel = QualityLevel.Simple;
        PlayerPrefs.SetString("GraphicsQuality", "Simple");      
    }

    public void Fast()
    {
        QualitySettings.currentLevel = QualityLevel.Fast;
        PlayerPrefs.SetString("GraphicsQuality", "Fast");       
    }

    public void Fastest()
    {
        QualitySettings.currentLevel = QualityLevel.Fastest;
        PlayerPrefs.SetString("GraphicsQuality", "Fastest");        
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

}
