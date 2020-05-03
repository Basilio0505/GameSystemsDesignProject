using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject[] gates;
    public GameObject OpenGateText;
    private bool facingButton;
    private bool isOpening;

    public levelManager manager;
    public GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        isOpening = false;
        facingButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (facingButton)
        {
            if (Input.GetKeyDown("e"))
            {
                isOpening = true;
                manager.SetCheckpoint(checkpoint);
            }
        }

        if (gates[0].transform.position.y > 10f)
        {
            isOpening = false;
        }
        if (isOpening)
        {
            for (int i = 0; i<gates.Length; i++)
            {
                gates[i].transform.Translate(Vector3.up * Time.deltaTime * 5);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenGateText.SetActive(true);
            facingButton = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenGateText.SetActive(false);
            facingButton = false;
        }
    }
}
