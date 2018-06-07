using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{

    public Dialogue dialogue;

    private void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void Talk()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FistCol")
        {
            Talk();
            print("it be workin");
        }
    }
}
