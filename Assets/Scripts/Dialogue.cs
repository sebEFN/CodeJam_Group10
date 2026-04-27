using EasyTextEffects;
using EasyTextEffects.Effects;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
public TextMeshProUGUI placeholder;
public TextEffect colorEffect;

 void Start()
    {
    }
    
    
public void nextText()
    {
            colorEffect.StartManualEffects();
            placeholder.text = "WTF! I.. where the fuck am i?!";  
            
    }
    public void RefreshText()
    {
            colorEffect.StartManualEffects();
    }

}
