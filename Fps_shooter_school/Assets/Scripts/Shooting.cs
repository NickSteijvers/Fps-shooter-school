using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Camera Cam;

    private Ray ray;
    private RaycastHit hit;

    public int beans = 150;

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
        {
            ray = Cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    Debug.Log("hit");
                    Destroy(hit.collider.gameObject);
                    beans = beans - 1;
                    Debug.Log(beans);
                }
            }
        }
        
      if (beans == 0) 
        {
            SceneManager.LoadScene(sceneName: "victory");
            Debug.Log("Victory");
        }
    }
}
