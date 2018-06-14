using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;
    public Animator animator;

    public static bool isTalking;
    public static bool talkEndedFrame = false;
    public static bool talkStartedFrame = false;
    public static string frameID;
    Dialogue lastDialogue;

    //GUI
    public GameObject talk;
    public GameObject click;

    private Queue<string> sentences;

    [HideInInspector]
    public string sentence;

  

    void Start ()
    {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        //Just in case, remove the prompt
        DisablePrompt();

        //This is if we need to check stuff outide this void
        lastDialogue = dialogue;

        if (talkEndedFrame == false)
        {
            talkStartedFrame = true;
            animator.SetBool("IsOpen", true);
            isTalking = true;
            sentences.Clear();
            FirstPersonController.canMove = false;

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        }
    }

    private void Update()
    {
        talkEndedFrame = false;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (isTalking && talkStartedFrame == false)
            {
                DisplayNextSentence();
            }
        }

        talkStartedFrame = false;
    }

    public void DisplayNextSentence()
    {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            sentence = sentences.Dequeue();
            StopAllCoroutines();
            TypeSentence(sentence);
            print(sentence.ToString());
    }

    void TypeSentence (string sentence2)
    {
        dialogueText.text = "";
        foreach(char letter in sentence2.ToCharArray())
        {
            dialogueText.text += letter;
            //yield return null;
        }
    }

    public void EndDialogue()
    {
        talkEndedFrame = true;
        animator.SetBool("IsOpen", false);
        isTalking = false;
        print("end of story");
        FirstPersonController.canMove = true;

        //This will kind of check if the player is still in the zone to activate/deactivate the prompt
        var people = FindObjectsOfType<TriggerDialogue>();
        foreach (TriggerDialogue triggerDialogue in people)
        {
            if(triggerDialogue.isInsideTalkZone == true)
            {
                //Disabled this because it's so buggy, and looks wierd with the box animation.
                //EnablePrompt();
            }
        }
        
        //If destroy when done is ticked, time for DESTRUCTION!
        if(lastDialogue.destroyWhenDone == true)
        {
            Destroy(gameObject);
        }


        DisablePrompt();

    }

    public void DisablePrompt()
    {
        //This disables the gui prompts to talk
        click.SetActive(false);
        talk.SetActive(false);
    }

    public void EnablePrompt()
    {
        //This enables the gui prompts to talk
        click.SetActive(true);
        talk.SetActive(true);
    }
}
