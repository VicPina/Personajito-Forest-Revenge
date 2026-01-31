using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    public NPCDialog DialogueData;
    public GameObject DialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
       if (DialogueData == null || (PauseControler.isGamePaused && !isDialogueActive) )
        {
            Debug.Log("No hay Dialogos!!!");
            return;
        }
       if (isDialogueActive)
        {
            nextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(DialogueData.NPCName);
        portraitImage.sprite = DialogueData.NPCPortrait;

        DialoguePanel.SetActive(true);
        PauseControler.setPaused(true);
        StartCoroutine(TypeLine());

    }

    void nextLine()
    {
        if(isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(DialogueData.dialogueLines[dialogueIndex]);    
            isTyping = false;
        }
        else if(++dialogueIndex < DialogueData.dialogueLines.Length) 
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping= true;
        dialogueText.SetText("");

        foreach(char letter in DialogueData.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            SoundEffectManager.PlayVoice(DialogueData.voiceSound, DialogueData.voicePitch);
            yield return new WaitForSeconds(DialogueData.typingSpeed);
        }

        isTyping = false;

        if(DialogueData.autoProgressLine.Length > dialogueIndex && DialogueData.autoProgressLine[dialogueIndex])
        {
            yield return new WaitForSeconds(DialogueData.autoProgressDelay);
            nextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        DialoguePanel.SetActive(false);
        PauseControler.setPaused(false);

    }
}
