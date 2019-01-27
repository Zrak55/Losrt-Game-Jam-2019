using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene("House_5");   
    }

    public void exit()
    {
        Application.Quit();
    }
    public void startwacgame()
    {
        Wack.gamestatewacky = true;
        SceneManager.LoadScene("House_5");   
    }


}

