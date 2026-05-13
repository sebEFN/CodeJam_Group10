using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string guyName;
    public Sprite guyImage;
    public string[] mainGuy;
}
