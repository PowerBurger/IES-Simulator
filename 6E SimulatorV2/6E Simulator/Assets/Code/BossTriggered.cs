using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggered : MonoBehaviour
{

    public GameObject Path;
    public GameObject HealthBar;
    public GameObject ExtraSpikes;
    public bool bossIsActive;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "ColDetector")
        {
            bossIsActive = true;
            Path.GetComponent<Rigidbody>().isKinematic = false;
            HealthBar.SetActive(true);
            ExtraSpikes.SetActive(true);
        }
    }
}