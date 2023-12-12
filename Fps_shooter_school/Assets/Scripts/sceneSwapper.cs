using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{

    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}