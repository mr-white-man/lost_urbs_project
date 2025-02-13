using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    

}
