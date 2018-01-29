using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Spawner : MonoBehaviour
{
    private Player player;

    public Transform lowPoint;
    public GameObject Player;
    public GameObject Boss;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if(Boss.transform.position.y < lowPoint.position.y)
        {
            Boss.transform.position = new Vector3(1.5f, 2.2f, 5.8f);
        }

        if (Player.transform.position.y < lowPoint.position.y)
        {
            Application.LoadLevel("Schoolyard");
        }
    }
}
