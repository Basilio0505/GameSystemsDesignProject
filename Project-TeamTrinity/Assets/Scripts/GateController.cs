using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject OpenGateText;
    private bool isOpening;

    // Start is called before the first frame update
    void Start()
    {
        isOpening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gate1.transform.position.y > 10f)
        {
            isOpening = false;
        }
        if (isOpening)
        {
            Gate1.transform.Translate(Vector3.up * Time.deltaTime * 5);
            Gate2.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
    }

    /*private void OnMouseDown()
    {
        isOpening = true;
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenGateText.SetActive(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                isOpening = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenGateText.SetActive(false);
        }
    }
}
