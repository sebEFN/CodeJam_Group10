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
        colorEffect.StartManualEffects();
    }
    
    
public void nextText()
    {
            placeholder.text = "HERE is my new message";
            //colorEffect.StopAllEffects();
            colorEffect.StartManualEffects();
    }
    public void RefreshText()
    {
            //colorEffect.StopAllEffects();
            colorEffect.StartManualEffects();
    }

}
