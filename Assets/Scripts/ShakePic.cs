using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShakePic : MonoBehaviour
{
    public RectTransform character1;
    public RectTransform character2;
    public RectTransform character3;

    public void OnButtonClick()
    {
        StartCoroutine(Shake(character1));
        StartCoroutine(Shake(character2));
        StartCoroutine(Shake(character3));
    }

    IEnumerator Shake(RectTransform target)
    {
        Vector2 startPos = target.anchoredPosition;

        for(int i = 0; i < 30; i++)
        {
            target.anchoredPosition = startPos + Random.insideUnitCircle * 10f;
            yield return new WaitForSeconds(0.05f);
        }

        target.anchoredPosition = startPos;
    }
}
