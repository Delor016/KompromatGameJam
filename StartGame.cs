using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string sceneToLoad;

    public void StartGame1()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
