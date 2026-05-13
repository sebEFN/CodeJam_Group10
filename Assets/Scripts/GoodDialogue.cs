using EasyTextEffects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

public class GoodDialogue : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextEffect colorEffect;
    public AudioSource talk;
    int who;
    public DialogueData guy;

    public void TheDialogue()
    {
        if (who < 0 || who >= guy.mainGuy.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
        DialogueText.text = guy.mainGuy[who];
        colorEffect.Refresh();
        colorEffect.StartManualEffects();
        talk.Play();
        who++;
        
    }
}
