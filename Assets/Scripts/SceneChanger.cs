using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void QuitGame()
    {
        Application.Quit();  
    }
    

}
