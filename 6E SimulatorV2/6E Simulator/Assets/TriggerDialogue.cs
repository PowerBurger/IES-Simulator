using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{

    public Dialogue dialogue;

    [HideInInspector]
    public bool isInsideTalkZone;

    private void Start()
    {
        
    }

    public void Update()
    {
        //This will start the dialogue if you click!
        if(Input.GetMouseButtonDown(0))
        {
            if (isInsideTalkZone && !DialogueManager.isTalking)
            {
                //Player is in the zone (and not already talking), so start the dialogue!
                Talk();

                //This will make the "click to talk" thing go away
                FindObjectOfType<DialogueManager>().DisablePrompt();
            }
        }
    }

    public void Talk()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FistCol")
        {
            //This will make the "click to talk" thing show up
            FindObjectOfType<DialogueManager>().EnablePrompt();

            //This will make it remember that it's in the zone (and make sure no other character is)
            var others = FindObjectsOfType<TriggerDialogue>();
            foreach(TriggerDialogue other in others)
            {
                other.isInsideTalkZone = false;
            }
                
            isInsideTalkZone = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FistCol")
        {
            //This will make the "click to talk" thing go away
            FindObjectOfType<DialogueManager>().DisablePrompt();

            isInsideTalkZone = false;
        }
    }
}
