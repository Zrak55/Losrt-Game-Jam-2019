using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int[] objectCounter;
    public int numObjectives;
    public int curObjective;
    public int instructionTimer;
    public int instTimMax;
    public bool objComp;

    public int objtwocount;
    public int objtwonum;
    public int[] objtwoaudiohint = new int[3];

    public int objthreecomp;
    public int objthreenum;

    public AudioSource soundsource;

    public AudioClip narration00;
    public AudioClip instruction00;
    public AudioClip narration01;
    public AudioClip instruction01;
    public AudioClip narration02;
    public AudioClip instruction02a; //bread in pantry
    public AudioClip instruction02b;  //PB on counter
    public AudioClip instruction02c;  //Jelly in fridge
    public AudioClip narration03;
    public AudioClip instruction03a; //get cup
    public AudioClip instruction03b; //get to sink
    public AudioClip narration04;
    public AudioClip instruction04;

    void Start()
    {
        for(int i=0; i<3; i++)
        {
            objtwoaudiohint[i] = 0;
        }
        objthreecomp = 0;
        objthreenum = 2;
        objtwocount = 0;
        objtwonum = 3;
        instTimMax = 7200;
        numObjectives = 5;
        curObjective = 0;
        instructionTimer = instTimMax;
        objComp = false;
        playInstruction(curObjective);
    }


    void Update()
    {
        checkObjective();
        if (instructionTimer > 0)
        {
            instructionTimer--;
        }
        else
        {
            playInstruction(curObjective);
            instructionTimer = instTimMax;
        }
        if (Input.GetKeyDown("i"))
        {
            playInstruction(curObjective);
        }
    }

    void checkObjective()
    {
        if (objComp)
        {
            soundsource.Pause();
            curObjective++;
            objComp = false;
            playNarration(curObjective);
            instructionTimer = instTimMax;
        }
    }

    void playNarration(int ob)
    {
        switch (ob)
        {
            case 0:
                {
                    soundsource.clip = narration00;
                    soundsource.Play();
                    break;
                }
            case 1:
                {
                    soundsource.clip = narration01;
                    soundsource.Play();
                    break;
                }
            case 2:
                {
                    soundsource.clip = narration02;
                    soundsource.Play();
                    break;
                }
            case 3:
                {
                    soundsource.clip = narration03;
                    soundsource.Play();
                    break;
                }
            case 4:
                {
                    soundsource.clip = narration04;
                    soundsource.Play();
                    break;
                }
            case 5:
                {
                    //use unity to play a sound instruction_05;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void playInstruction(int ob)
    {
        switch (ob)
        {
            case 0:
                {
                    soundsource.clip = instruction00;
                    soundsource.Play();
                    break;
                }
            case 1:
                {
                    soundsource.clip = instruction01;
                    soundsource.Play();
                    break;
                }
            case 2:
                {
                    bool hintNotGiven = true;
                    while(hintNotGiven)
                    {
                        int hint = (int)Random.Range(1f, 3.99999f);
                        if (objtwoaudiohint[hint] == 0)
                        {
                            if (hint == 0)
                            {
                                soundsource.clip = instruction02a;
                            }
                            else if (hint == 1)
                            {
                                soundsource.clip = instruction02b;
                            }
                            else if (hint == 2)
                            {
                                soundsource.clip = instruction02c;
                            }
                            hintNotGiven = false;
                            soundsource.Play();
                        }
                    }
                    break;

                }
            case 3:
                {
                    if(objthreecomp==0)
                    {
                        soundsource.clip = instruction03a;
                    }
                    else
                    {
                        soundsource.clip = instruction03b;
                    }
                    soundsource.Play();
                    break;
                }
            case 4:
                {
                    
                    soundsource.clip = instruction04;
                    soundsource.Play();
                    break;
                }
            case 5:
                {
                    //use unity to play a sound instruction_05;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}