using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/New Dialogue", order = 1)]
public class DialogueData : ScriptableObject
{
    public List<DialogueEntry> Entries;
}

[System.Serializable]
public class DialogueEntry
{
    public string NPCName;
    public string DialogueText;
    public List<Response> Responses;
}

[System.Serializable]
public class Response
{
    public string PlayerText;
    public int NextDialogueEntry;  // Use this to point to the next DialogueEntry by index. -1 means the end of conversation.
}
