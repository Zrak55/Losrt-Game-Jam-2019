using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene("");   // At end
    }

    public void exit()
    {
        Application.Quit();
    }


}

