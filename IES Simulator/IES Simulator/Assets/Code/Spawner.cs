using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class Spawner : MonoBehaviour
{
    private GameObject player;

    public Transform lowPoint;
    public GameObject Player;
    public GameObject Boss;
    public GameObject loading;

    private void Start()
    {
        player = GameObject.Find("FPSController");
    }
    void Update()
    {
        if(Boss.transform.position.y < lowPoint.position.y)
        {
            Boss.transform.position = new Vector3(1.5f, 2.2f, 5.8f);
        }

        if (Player.transform.position.y < lowPoint.position.y)
        {
            loading.SetActive(true);
            SceneManager.LoadScene("Schoolyard");
        }
    }
}
