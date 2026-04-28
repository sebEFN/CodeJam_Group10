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
private int i = 0;
private int j = 0;
private int k = 0;
private int t = 0;
[SerializeField] DialogueData guy;

 void Start()
        {
                Debug.Log("start");
               
        }
    
    
public void MainGuydia()
    {
            colorEffect.StartManualEffects();
                if (i <= guy.mainGuy.Length)
                {
                        placeholder.text = guy.mainGuy[i];
                        i++;
                        Debug.Log(i);
                }
            
    }
    public void KaiDia()
    {
            colorEffect.StartManualEffects();
                if (j <= guy.kai.Length)
                {
                        placeholder.text = guy.kai[j];
                        j++;
                        Debug.Log(j);
                }
            
    }

    public void AnibaDia()
    {
            colorEffect.StartManualEffects();
                if (k <= guy.aniba.Length)
                {
                        placeholder.text = guy.aniba[k];
                        k++;
                }
            
    }

    public void AmalAI()
    {
            colorEffect.StartManualEffects();
                if (t <= guy.ai.Length)
                {
                        placeholder.text = guy.ai[t];
                        t++;
                }
            
    }

}
