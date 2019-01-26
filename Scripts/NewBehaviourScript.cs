using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool echo;
    public GameObject prefabLight;
    GameObject prefabLightClone;
    private int cooldown;
    // Start is called before the first frame update
    void Start()
    {
        echo = false;
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            echo = true;
        }
        else if(echo == true && !Input.GetKeyDown("q"))
        {
            echo = false;
        }

        if(echo == true && cooldown == 0)
        {
            prefabLightClone = Instantiate(prefabLight, transform.position + (prefabLight.transform.up * (2*(1/2))), Quaternion.identity) as GameObject;
            cooldown = 100;
        }
        if(cooldown != 0)
        {
            cooldown--;
        }

    }
}
