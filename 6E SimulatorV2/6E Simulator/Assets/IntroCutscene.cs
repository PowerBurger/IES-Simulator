using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class IntroCutscene : MonoBehaviour {

    public Animator cutsceneCamera;
    public Image black;
    public float timer = 12;
    bool flip;
    GameObject player;
    public GameObject makeshiftPlayerStatue;
    public bool enableCutsceneInUnityEditor;

    void Start ()
    {
        player = GameObject.Find("FPSController");
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (enableCutsceneInUnityEditor)
            {
                player.SetActive(false);
            }
            else
            {
                CutsceneOver();
                enabled = false;
            }
        }
        else
        {
            player.SetActive(false);
        }

        cutsceneCamera.gameObject.SetActive(true);
        GameObject.Find("Scene Manager").GetComponent<PauseMenu>().enabled = false;
    }
	
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Color temp;
            temp = black.color;

            if (!flip)
            {
                //This will make it less transparent over time   
                temp.a += Time.deltaTime;
                black.color = temp;
            }

            if (flip)
            {
                //This will make it more transparent over time
                temp.a -= Time.deltaTime;
                black.color = temp;
            }

            if (temp.a >= 1)
            {
                flip = !flip;
                CutsceneOver();
            }

        }
    }

    void CutsceneOver()
    {
        //This will happen when you get control over the character

        //Enable the player
        player.SetActive(true);
        player.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;

        //Enable the pause menu stuffs
        GameObject.Find("Scene Manager").GetComponent<PauseMenu>().enabled = true;

        //Now away with the cutscene camera!
        Destroy(cutsceneCamera.gameObject);

        //And away with the statue of the player
        Destroy(makeshiftPlayerStatue);
    }
}
