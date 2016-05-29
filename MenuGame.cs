using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
