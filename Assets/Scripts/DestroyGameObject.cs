using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    public GameObject target;

    public void DestroyTarget()
    {
        Destroy(target);
    }
}