using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    public Transform cameraTransform;
    public Transform colliderTransform;
    private Vector3 crouchAdjust;

    public bool isCrouching = false;

    public bool facingDistract;
    private GameObject DistractionItem;
    public GameObject PickUpItemText;
    public GameObject InvFullText;
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public int inventory;

    // Start is called before the first frame update
    void Start()
    {
        crouchAdjust = new Vector3(0, 0.5f, 0);
        inventory = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (facingDistract)
        {   
            if(inventory >= 3)
            {
                InvFullText.SetActive(true);
            }
            else if (Input.GetKeyDown("e"))
            {
                
            }
        }

        if (Input.GetKeyDown("left ctrl"))
        {
            //Debug.Log("CROUCHING");
            isCrouching = true;
            cameraTransform.position -= crouchAdjust;
            colliderTransform.position -= crouchAdjust;
            controller.m_WalkSpeed = 3;
        }
        else if(isCrouching == true && Input.GetKeyUp("left ctrl"))
        {
            //Debug.Log("NOT CROUCHING");
            isCrouching = false;
            cameraTransform.position += crouchAdjust;
            colliderTransform.position += crouchAdjust;
            controller.m_WalkSpeed = 5;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameOverScreen.SetActive(true);
            //controller.m_MouseLook.clampVerticalRotation = false;
            //controller.m_MouseLook.lockCursor = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            controller.enabled = false;
        }

        if (other.tag == "Distract")
        {
            DistractionItem = other.gameObject;
            PickUpItemText.SetActive(true);
            facingDistract = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Distract")
        {
            PickUpItemText.SetActive(false);
            InvFullText.SetActive(false);
            facingDistract = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
