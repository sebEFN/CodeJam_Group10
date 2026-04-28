using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
public class DialogueData : ScriptableObject
{
    struct Dialogue
    {
        public TextMeshProUGUI MyDialogue;
    }
}
