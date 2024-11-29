using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private bool isDialogue = false;
    private int index = 0;
    public class Dialogue
    {
        public string name;
        public string dialogue;

        public Dialogue(string name, string dialogue)
        {
            this.name = name;
            this.dialogue = dialogue;
        }
    }

    private Dialogue[] dialogues = new Dialogue[]
    {
        new Dialogue("bad gay", "u ded"),
        new Dialogue("you", "ohno"),
        new Dialogue("bud gay", "What are you up to?"),
        new Dialogue("yuo", "Just exploring the world."),
    };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDialogue)
        {
            dialogueManager.CloseDialogue();
            index++;
            if (index < dialogues.Length)
            {
                dialogueManager.ShowDialogue(dialogues[index].name, dialogues[index].dialogue);
            }
            else
            {
                isDialogue = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && !isDialogue && index<dialogues.Length)
        {
            dialogueManager.ShowDialogue(dialogues[index].name, dialogues[index].dialogue);
            isDialogue = true;
        }
    }
}
