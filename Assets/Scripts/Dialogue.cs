using EasyTextEffects;
using EasyTextEffects.Effects;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
public TextMeshProUGUI placeholder;
public TextEffect colorEffect;
AudioSource audioData;
public AudioSource talk;
private int i = 0;
private int j = 0;
private int k = 0;
private int t = 0;

public GameObject AnibaOB;
public GameObject KaiOB;

    [SerializeField] DialogueData guy;

 void Start()
        {
                Debug.Log("start");
               audioData = GetComponent<AudioSource>();
        }
    
    
public void MainGuydia()
    {
                if (i < 7)
                {
                        placeholder.text = guy.mainGuy[i];
                        i++;
                        Debug.Log(i);
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
           talk.Play(0);
                }
        else
        {
            
        }
            
    }
    public void KaiDia()
    {
        
                if (j < 7)
                {
                        placeholder.text = guy.kai[j];
                        Debug.Log(j);
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
            talk.Play(0);
            if (j == 1)
            {
                audioData.Play(0);
            }
            j++;
                }
            else
        {
            Debug.Log("finished");
            SceneManager.LoadScene("SecondScene");
        }
    }

    public void AnibaDia()
    {
        Debug.Log("aniba");
        if (k < 5)
                {
                        placeholder.text = guy.aniba[k];
                        k++;
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
            talk.Play(0);
                }
            else
            {
                 SceneManager.LoadScene("thirdScene");
            }
    }
    public void AnibaDiatwo()
    {
        Debug.Log("aniba");
        if (k+5 < guy.aniba.Length)
                {
                        placeholder.text = guy.aniba[k+5];
                        k++;
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
            talk.Play(0);
                }
            else
            {
               
            }
    }

    public void AmalAI()
    {

                if (t <= guy.ai.Length && i+18 >= guy.mainGuy.Length)
                {
                        placeholder.text = guy.ai[t];
                                colorEffect.Refresh();
            colorEffect.StartManualEffects();
            talk.Play(0);
                }
        else
        {
            Debug.Log("meow");
        }
    }

    public void MainGuydiaTwo()
    {
        if (i+7 < guy.mainGuy.Length)
        {
            placeholder.text = guy.mainGuy[i+7];
            i++;
            Debug.Log(i);
            colorEffect.Refresh();
            colorEffect.StartManualEffects();
            talk.Play(0);
        }
        else
        {
            Debug.Log("finished");
        }

    }

    public void KaiDiaTwo()
    {

        if (j + 7 < guy.kai.Length)
        {
            placeholder.text = guy.kai[j + 7];
            Debug.Log(j);
            colorEffect.Refresh();
            colorEffect.StartManualEffects();
            talk.Play(0);
            j++;
        }

        else
        {
            AnibaOB.SetActive(true);
            KaiOB.SetActive(false);
            AnibaDia();    
        }
    }
public void MainGuydiathree()
    {
                if (i+15 < guy.mainGuy.Length)
                {
                        placeholder.text = guy.mainGuy[i+15];
                        i++;
                        Debug.Log(i);
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
           talk.Play(0);
                }
        else
        {
            Debug.Log("finished");
        }
    }

    public void MainGuydiaFour()
    {
                if (i+16 < guy.mainGuy.Length)
                {
                        placeholder.text = guy.mainGuy[i+16];
                        i++;
                        Debug.Log(i);
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
           talk.Play(0);
                }
        else
        {
            i++;
            AnibaOB.SetActive(true);
            KaiOB.SetActive(false);
            
        }


    }
}