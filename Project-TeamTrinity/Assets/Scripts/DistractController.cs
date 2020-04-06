using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractController : MonoBehaviour
{
    private float timer = 4f;
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            Debug.Log("DESTROY");
            if(enemy != null)
            {
                enemy.GetComponent<EnemyController>().searchSpot = transform.position;
            }
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemy = other.gameObject;
        }
    }
}
