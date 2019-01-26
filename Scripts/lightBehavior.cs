using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBehavior : MonoBehaviour
{
    private int lifetime;
    private static int movespeed = 2;
    private Vector3 userDirection = Vector3.right;
    public Light lightsource;

    public AudioSource audiosource;
    public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = 60;
        userDirection = Camera.main.transform.forward;
        audiosource.clip = click;
        audiosource.Play();
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
        
        //lightsource.intensity -= .015f;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        float x = Random.Range(0f, 0.25f);
        float xval = userDirection.x + x;
        if(xval>1)
        {
            xval--;
        }

        //float yval = userDirection.y + x;
        //if (yval > 1)
        //{
          //  yval--;
        //}

        float zval = userDirection.z + x;
        if (zval > 1)
        {
            zval--;
        }
        userDirection.Set(xval, -userDirection.y, zval);
    }
}
