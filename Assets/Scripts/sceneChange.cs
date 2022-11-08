using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class sceneChange : MonoBehaviour
{
    void OnAmongus(InputValue input)
    {

        if(input.Get<float>() < 0f)
        {
            SceneManager.LoadScene(1);
        }
        else if (input.Get<float>() > 0f)
        {
            SceneManager.LoadScene(0);
        }

    }
    void Onexit(InputValue input)
    {
        Application.Quit();
    }
}
