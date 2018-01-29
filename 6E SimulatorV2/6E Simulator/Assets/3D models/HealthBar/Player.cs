using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Stat Health;
    public GameObject HealthBar;
    public Rigidbody FPSController;

    public GameObject Boss;
    public Transform lowPoint;

    private void Awake()
    {
        Health.Initialize();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Health.CurrentVal == 0)
        {
            Destroy(gameObject);
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
