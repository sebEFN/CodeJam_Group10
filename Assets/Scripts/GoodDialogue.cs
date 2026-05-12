using EasyTextEffects;
using TMPro;
using UnityEngine;
using System.Linq;

public class GoodDialogue : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextEffect colorEffect;
    public AudioSource talk;
    [SerializeField] DialogueData guy;
    int who;
    public void TheDialogue()
    {
         if (who < 0 || who >= guy.mainGuy.Length)
            return;

        DialogueText.text = guy.mainGuy[who];

        colorEffect.Refresh();
        colorEffect.StartManualEffects();
        talk.Play();
        who++;
    }
}
