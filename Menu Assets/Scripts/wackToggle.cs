using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wack : MonoBehaviour
{
    private Toggle tglWack;
    public void update()
    {
        if (tglWack.isOn == true)
        {
            Wack.gamestatewacky = true;
            
        }
        else
            Wack.gamestatewacky = false;
    }
   

}

