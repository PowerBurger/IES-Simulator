using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Networking;
using UnityEngine.UI;
//using UnityStandardAssets.Characters.FirstPerson;

public class Connect : MonoBehaviour
{

    //public string IpAddress;
    //public int Port;
    Text playback;
    public Transform Player;
    public Camera cam;
    public Camera Realcam;

    public GameObject loadingScreen;
    public GameObject titleScreen;
    public UnityEngine.UI.Slider sliderr;

    void Start ()
    {
        playback = GetComponent<Text>();
        Screen.lockCursor = false;

        if(PlayerPrefs.GetString("GraphicsQuality") == "Fantastic")
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
        }

        if (PlayerPrefs.GetString("GraphicsQuality") == "Beautiful")
        {
            QualitySettings.currentLevel = QualityLevel.Beautiful;
        }

        if (PlayerPrefs.GetString("GraphicsQuality") == "Good")
        {
            QualitySettings.currentLevel = QualityLevel.Good;
        }

        if (PlayerPrefs.GetString("GraphicsQuality") == "Simple")
        {
            QualitySettings.currentLevel = QualityLevel.Simple;
        }

        if (PlayerPrefs.GetString("GraphicsQuality") == "Fast")
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
        }

        if (PlayerPrefs.GetString("GraphicsQuality") == "Fastest")
        {
            QualitySettings.currentLevel = QualityLevel.Fastest;
        }
    }
	
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(true);
            
        }
	}

    public void StartHost()
    {
        //StartCoroutine(LoadAsyncronously());
        UnityEngine.SceneManagement.SceneManager.LoadScene("Schoolyard");
    }

    IEnumerator LoadAsyncronously()
    {
        //AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Schoolyard");

        loadingScreen.SetActive(true);
        titleScreen.SetActive(false);

        bool done = false;

        while (!done)
        {
            float progress = Mathf.Clamp01(1 / .9f);

            sliderr.value = progress;
        }

        yield return null;
    }

    public void join()
    {
        //NetworkManager.singleton.networkAddress = IpAddress;
        //NetworkManager.singleton.networkPort = Port;
        //NetworkManager.singleton.StartClient();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        Application.LoadLevel("Options");
    }

    public void Back()
    {
        Application.LoadLevel("TitleScreen");
    }

    public void HowToPlay()
    {
        Application.LoadLevel("HowToPlay");
    }
  
}
