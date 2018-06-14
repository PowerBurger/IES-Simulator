using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;
    public Animator animator;

    public static bool isTalking;

    //GUI
    public GameObject talk;
    public GameObject click;

    private Queue<string> sentences;

    [HideInInspector]
    public string sentence;

    private void Update()
    {
        //print(sentences);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    void Start ()
    {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        isTalking = true;
        sentences.Clear();
        FirstPersonController.canMove = false;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
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
                EnablePrompt();
                return;
            }
        }
        
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
