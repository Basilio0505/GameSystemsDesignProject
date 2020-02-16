using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] waypoints;
    private NavMeshAgent myAgent;
    private int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.destination = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If enemy has reached waypoint
        if (Vector3.Distance(myAgent.destination, transform.position) <= 1)
        {
            //current waypoint updated to next one
            currentWaypoint++;
            //if already reached last waypoint
            if (currentWaypoint >= waypoints.Length)
            {
                //reset to first waypoint
                currentWaypoint = 0;
            }
            //enemy destination set to current waypoint
            myAgent.destination = waypoints[currentWaypoint].transform.position;
        }
    }
}
