using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetMouseButtonDown(0))
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
        isTalking = true;
        animator.SetBool("IsOpen", true);
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //DisplayNextSentence();
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
        StartCoroutine(TypeSentence(sentence));
        print(sentence.ToString());
    }

    IEnumerator TypeSentence (string sentence2)
    {
        dialogueText.text = "";
        foreach(char letter in sentence2.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        isTalking = false;
        animator.SetBool("IsOpen", false);
        print("end of story");

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
