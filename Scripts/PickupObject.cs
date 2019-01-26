using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {
	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;
    public GameController gc;
    // Use this for initialization
    void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(carrying) {
			carry(carriedObject);
			checkDrop();
			//rotateObject();
		} else {
			pickup();
		}
	}
	
	void rotateObject() {
		carriedObject.transform.Rotate(5,10,15);
	}
	
	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}
	
	void pickup() {
		if(Input.GetMouseButtonDown(1)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                if (gc.curObjective == 0)
                {
                    Objective0 ozero = hit.collider.GetComponent<Objective0>();
                    if (ozero != null)
                    {
                        Destroy(ozero.gameObject);
                        gc.objComp = true;

                    }
                }
                else if (gc.curObjective == 1)
                {
                    Objective1 oone = hit.collider.GetComponent<Objective1>();
                    if (oone != null)
                    {
                        gc.objComp = true;

                    }
                }
                else if (gc.curObjective == 2)
                {
                    Objective2 othree = hit.collider.GetComponent<Objective2>();
                    if (othree != null)
                    {
                        gc.objtwocount++;
                        Destroy(othree.gameObject);
                        if (gc.objtwocount >= gc.objthreenum)
                        {
                            gc.objComp = true;
                        }
                    }
                }
                else if (gc.curObjective == 3)
                {
                    if (gc.objthreecomp == 0)
                    {
                        Objective3 otwo = hit.collider.GetComponent<Objective3>();
                        if (otwo != null)
                        {
                            GameObject material = otwo.gameObject;
                            if(material.name=="Fridge")
                            {
                                if(gc.objtwoaudiohint[2] == 0)
                                {
                                    gc.objthreecomp++;
                                    gc.objtwoaudiohint[2] = 1;
                                }
                            }
                            else if(material.name == "PB")
                            {
                                Destroy(otwo.gameObject);
                                gc.objthreecomp++;
                                gc.objtwoaudiohint[1] = 1;

                            }
                            else if(material.name == "Bread")
                            {
                                Destroy(otwo.gameObject);
                                gc.objthreecomp++;
                                gc.objtwoaudiohint[0] = 1;
                            }
                            
                        }
                    }
                    else
                    {
                        Objective3Stat otwo = hit.collider.GetComponent<Objective3Stat>();
                        if (otwo != null)
                        {
                            gc.objthreecomp++;
                            gc.objComp = true;
                        }
                    }
                }
                else if(gc.curObjective==4)
                {
                    Objective4 ofour = hit.collider.GetComponent<Objective4>();
                    if (ofour != null)
                    {
                        gc.objComp = true;
                        //send us to the end screen
                    }
                }
            }
		}
	}
	
	void checkDrop() {
		if(Input.GetMouseButtonDown(1)) {
			dropObject();
		}
	}
	
	void dropObject() {
		carrying = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
	}
}

