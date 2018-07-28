using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerController : MonoBehaviour
{
    private bool uiActive;
    public GameObject itemUI;
    public UnityEvent PauseMenu;
    public float rotSpeed = 1;
    private Rigidbody rB;
    public int speed;

    bool move = true;

    private void OnEnable()
    {
        EventManager.StartListening("OnFreezeMovement", MovementToggle);
    }

    public void MovementToggle ()
    {
        if (move == true)
        {
            move = false;
        }
        else
        {
            move = true;
        }
    }

    void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (move == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(-Vector3.forward * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Translate(-Vector3.left * speed * Time.deltaTime);
        }
    }

    //void Update()
    //{
    //    float moveHorizontal = Input.GetAxisRaw("Horizontal");
    //    float moveVertical = Input.GetAxisRaw("Vertical");
    //
    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);       
    //    rB.AddForce(movement * speed);
    //    transform.rotation = (Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, movement.normalized, rotSpeed * Time.deltaTime, 0)));
    //}


    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Computer"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                col.GetComponent<Computer>().curTime++;               // adds time while held
                col.GetComponent<Computer>().loadbar.transform.localScale += new Vector3(0, 0, 0.0066f); //increases the width of the object of that timescale

                if ((col.GetComponent<Computer>().curTime / 60) >= col.GetComponent<Computer>().uploadTime) //once the current time held is greater than the upload time variable
                {
                    col.GetComponent<Inventory>().Items[0] = gameObject.GetComponent<Inventory>().Items[0]; //Grabs the item in the player slot                                                                                                              //
                    col.GetComponent<Computer>().hasUploaded = true;                                        //sets the computer to have been uploaded and turns off the loadbar
                    col.GetComponent<Computer>().loadbar.SetActive(false);
                }
            }
        }
        else if (col.gameObject.CompareTag("Item"))
        {
            if (col.gameObject.GetComponent<Inventory>().Items[0] != null)
            {
                itemUI = GameObject.Find(col.gameObject.GetComponent<Inventory>().Items[0].name);
            }
            else
            {
            }
            // if container, get the current item name from that and store it as the itemUI

            if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (GameObject.Find(col.gameObject.GetComponent<Inventory>().Items[0].name) == null) //Check if the UI has been made
                {
                    Debug.LogError("No gameObject attached to canvas");
                }
                if ((col.gameObject.GetComponent<Inventory>().Items[0].name) == ("Empty"))   //this is for swaping an item back into a container, therfore not requiring a ui element but a transfer anyways 
                {
                    gameObject.GetComponent<Inventory>().Swap(col.gameObject);
                    itemUI.transform.GetChild(0).gameObject.SetActive(false);
                    uiActive = false;
                }
                else
                {
                    itemUI.transform.GetChild(0).gameObject.SetActive(true);
                    uiActive = true;
                }
            }
            //menu action settings 
            if (Input.GetKeyDown(KeyCode.UpArrow) && uiActive == true)
            {
                gameObject.GetComponent<Inventory>().Swap(col.gameObject); //swap the item and set the ui to false
                itemUI.transform.GetChild(0).gameObject.SetActive(false);
                uiActive = false;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && uiActive == true)
            {
                itemUI.transform.GetChild(0).gameObject.SetActive(false); //set the ui to false
                uiActive = false;
            }

        }
    }
}
