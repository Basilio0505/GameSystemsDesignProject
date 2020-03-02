using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject GameOverScreen;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
