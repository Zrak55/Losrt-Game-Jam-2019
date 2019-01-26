using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBehavior : MonoBehaviour
{
    private int lifetime;
    private static int movespeed = 3;
    private Vector3 userDirection = Vector3.right;


    // Start is called before the first frame update
    void Start()
    {
        lifetime = 60;
        userDirection = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //Countdown to object deletion
        lifetime = lifetime - 1;

        //if the Object is at the end of its life, delete it. 
        if(lifetime == 0)
        {
            Destroy(gameObject);
        }

        //Move the object forwards
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }
}
