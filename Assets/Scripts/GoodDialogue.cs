using EasyTextEffects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

public class GoodDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextEffect colorEffect;
    public AudioSource talk;
    public GameObject myGuy;
    public DialogueTurn[] conversation;
    int who;
    public void NextDialogue()
    {
        who++;
        Debug.Log(who);
        if (who >= conversation.Length -2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        TheDialogue();
    }
    public void TheDialogue()
    {
        
        DialogueTurn turn = conversation[who];
        dialogueText.text = turn.character.mainGuy[turn.lineIndex];
        Image img = myGuy.GetComponent<Image>();
        img.sprite = turn.character.guyImage;
        colorEffect.Refresh();
        colorEffect.StartManualEffects();
        talk.Play();
    }
}
