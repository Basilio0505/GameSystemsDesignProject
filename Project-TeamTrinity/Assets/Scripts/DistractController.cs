using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractController : MonoBehaviour
{
    public bool startCount;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);

            if(timer <= 0f)
            {
                Debug.Log("DESTROY");
                Destroy(gameObject);
            }
        }
    }
}
