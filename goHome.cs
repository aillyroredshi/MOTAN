using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goHome : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
