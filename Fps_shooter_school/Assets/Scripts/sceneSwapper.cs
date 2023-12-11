using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{
   
    public void MoveToScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
       if (sceneId == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
       else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}