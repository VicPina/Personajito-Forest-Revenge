using UnityEngine;

[CreateAssetMenu(fileName ="NewNPCDialogue", menuName ="NPC Dialogue")]
public class NPCDialog : ScriptableObject
{
    public string NPCName;
    public Sprite NPCPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLine;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;
    

}
