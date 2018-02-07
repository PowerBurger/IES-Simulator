using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat Health;
    public GameObject HealthBar;
    public Rigidbody FPSController;

    public GameObject Boss;
    public Transform lowPoint;
    public GameObject loading;

    private void Awake()
    {
        Health.Initialize();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Health.CurrentVal == 0)
        {
            PlayerPrefs.SetInt("defeatedBoss1", 1);
            loading.SetActive(true);
            SceneManager.LoadScene("Schoolyard");
        }

        if (Boss.transform.position.y < lowPoint.position.y)
        {
            Health.CurrentVal -= 20;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Spikes")
        {
            Health.CurrentVal -= 10;
        }
    }
}
