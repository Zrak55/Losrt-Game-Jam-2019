using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wackyvolumescript : MonoBehaviour
{
    public Slider sldrVolume;
    public void Update()
    {
        AudioListener.volume = sldrVolume.value;
    }

}
