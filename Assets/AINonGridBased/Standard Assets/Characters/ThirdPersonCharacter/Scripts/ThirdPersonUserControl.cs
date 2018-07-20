
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

        private bool uiActive;
        public GameObject itemUI;
        public UnityEvent PauseMenu;
        private void Start()
        {

                if (Camera.main != null)
                {
                    m_Cam = Camera.main.transform;
                }
                else
                {
                    Debug.LogWarning(
                        "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                    // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
                }
                m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void FixedUpdate()
        {
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                bool crouch = Input.GetKey(KeyCode.C);
                m_Character.Move(m_Move, crouch, m_Jump);
                if (m_Cam != null)
                {
                    // calculate camera relative direction to move:
                    m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                    m_Move = v * m_CamForward + h * m_Cam.right;
                }
                else
                {
                    // we use world-relative directions in the case of no main camera
                    m_Move = v * Vector3.forward + h * Vector3.right;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.DownArrow))
            {
                PauseMenu.Invoke();
                Time.timeScale = 0;
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
            } 

        }
        public void OnTriggerStay(Collider col)
        {
            if (col.gameObject.CompareTag("Computer"))
            {
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    col.GetComponent<Computer>().curTime++;
                    col.GetComponent<Computer>().loadbar.transform.localScale += new Vector3(0, 0, 0.0066f);

                    if ((col.GetComponent<Computer>().curTime / 60) >= col.GetComponent<Computer>().uploadTime)
                    {
                        col.GetComponent<Inventory>().Items[0] = gameObject.GetComponent<Inventory>().Items[0];
                        col.GetComponent<Computer>().hasUploaded = true;
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

                if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (GameObject.Find(col.gameObject.GetComponent<Inventory>().Items[0].name) == null)
                    {
                        Debug.LogError("No gameObject attached to canvas");
                    }
                    if ((col.gameObject.GetComponent<Inventory>().Items[0].name) == ("Empty"))
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
                if (Input.GetKeyDown(KeyCode.UpArrow) && uiActive == true)
                {
                    gameObject.GetComponent<Inventory>().Swap(col.gameObject);
                    itemUI.transform.GetChild(0).gameObject.SetActive(false);
                    uiActive = false;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && uiActive == true)
                {
                    itemUI.transform.GetChild(0).gameObject.SetActive(false);
                    uiActive = false;
                }

            }
        }
    }
}


/*
 * If arrows are held
 * Check if collided is a computer
 * If so add curtime uploading and extend load bar
 * Once uploading equal user wanted upload time
 * get the item uploading, set computer to has upload, set the loadbar to off
 * 
 * If arrows are clicked
 * check if collided has tag item
 * start the ui for the item
 * if up is pressed, swap the item and turn it off
 * if down is pressed, turn off the ui
 */
