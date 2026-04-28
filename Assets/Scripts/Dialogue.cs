using EasyTextEffects;
using EasyTextEffects.Effects;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
public TextMeshProUGUI placeholder;
public TextEffect colorEffect;
AudioSource audioData;
private int i = 0;
private int j = 0;
private int k = 0;
private int t = 0;
[SerializeField] DialogueData guy;

 void Start()
        {
                Debug.Log("start");
               audioData = GetComponent<AudioSource>();
        }
    
    
public void MainGuydia()
    {
                if (i < guy.mainGuy.Length)
                {
                        placeholder.text = guy.mainGuy[i];
                        i++;
                        Debug.Log(i);
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
                }
        else
        {
            Debug.Log("finished");
        }
            
    }
    public void KaiDia()
    {
        
                if (j < guy.kai.Length)
                {
                        placeholder.text = guy.kai[j];
                        Debug.Log(j);
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
            if (j == 1)
            {
                audioData.Play(0);
            }
            j++;
                }
            else
        {
            Debug.Log("finished");
        }
    }

    public void AnibaDia()
    {
                if (k <= guy.aniba.Length)
                {
                        placeholder.text = guy.aniba[k];
                        k++;
                        colorEffect.Refresh();
            colorEffect.StartManualEffects();
                }
            
    }

    public void AmalAI()
    {

                if (t <= guy.ai.Length)
                {
                        placeholder.text = guy.ai[t];
                        t++;
                                colorEffect.Refresh();
            colorEffect.StartManualEffects();
                }
            
    }

}
