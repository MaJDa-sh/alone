using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject DialoguePrefab;
    private GameObject currentDialogueInstance;

    public void ShowDialogue(string person, string dialogue)
    {

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            currentDialogueInstance = Instantiate(DialoguePrefab, canvas.transform);

            TMP_Text nameText = currentDialogueInstance.transform.Find("NameText").GetComponent<TMP_Text>();
            TMP_Text dialogueText = currentDialogueInstance.transform.Find("DialogueText").GetComponent<TMP_Text>();

            if (nameText != null)
            {
                nameText.text = person;
            }

            if (dialogueText != null)
            {
                dialogueText.text = dialogue;
            }
        }
        else
        {
            Debug.LogError("No Canvas found in the scene.");
        }
    }

    public void CloseDialogue()
    {
        if (currentDialogueInstance != null)
        {
            Destroy(currentDialogueInstance);
            currentDialogueInstance = null; // Clear the reference
        }
    }
}
