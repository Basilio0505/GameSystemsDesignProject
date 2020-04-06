using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent myAgent;
    //public Animator anim;

    public enum State
    {
        PATROL,
        CHASE,
        SEARCH
    }
    public State state;
    private bool gameOver;

    public GameObject[] waypoints;
    private int currentWaypoint;
    public float patrolSpeed = 3f;

    public float chaseSpeed = 5f;
    public GameObject player;

    public Vector3 searchSpot;
    private float timer;
    public float searchWait = 10;

    private float heightMultiplyer;
    private float sightDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        myAgent = GetComponent<NavMeshAgent>();
        myAgent.destination = waypoints[currentWaypoint].transform.position;

        myAgent.updatePosition = true;
        myAgent.updateRotation = true;

        state = EnemyController.State.PATROL;
        gameOver = false;

        heightMultiplyer = 0.8f;

        StartCoroutine("EnemyStates");
    }

    IEnumerator EnemyStates()
    {
        while (!gameOver)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
                case State.SEARCH:
                    Search();
                    break;
            }
            yield return null;
        }
    }

    void Patrol()
    {
        myAgent.speed = patrolSpeed;
        //If enemy has reached waypoint
        if (Vector3.Distance(myAgent.destination, transform.position) <= 2)
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

    void Chase()
    {
        myAgent.speed = chaseSpeed;

        if (player != null)
        {
            Debug.Log("ENEMY: CHASING");

            searchSpot = player.transform.position;
            myAgent.SetDestination(searchSpot);

            if (Vector3.Distance(player.transform.position, transform.position) > 10)
            {
                Debug.Log("ENEMY: GOING INTO SEARCH - OUT OF RANGE");
                searchSpot = player.transform.position;
                state = EnemyController.State.SEARCH;
            }
        }
        else if(player == null)
        {
            Debug.Log("ENEMY: GOING INTO SEARCH - OBJECT NULL");
            state = EnemyController.State.SEARCH;
        }
    }

    void Search()
    {
        timer += Time.deltaTime;
        myAgent.SetDestination(this.transform.position);
        transform.LookAt(searchSpot);
        if(timer >= searchWait)
        {
            state = EnemyController.State.PATROL;
            timer = 0;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        state = EnemyController.State.CHASE;
    //        player = other.gameObject;
    //    }
    //}

    void FixedUpdate()
    {
        RaycastHit hit;

        //Debug lines to show sight cone and detection height
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, transform.forward * sightDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, (transform.forward + transform.right).normalized * sightDistance, Color.green);
        Debug.DrawRay(transform.position + Vector3.up * heightMultiplyer, (transform.forward - transform.right).normalized * sightDistance, Color.green);

        if (!gameOver)
        {
            //Raycsat Straight ahead
            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, transform.forward, out hit, sightDistance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    player = hit.collider.gameObject;
                    state = EnemyController.State.CHASE;
                }
                if (hit.collider.gameObject.tag == "Projectile")
                {
                    player = hit.collider.gameObject;
                    state = EnemyController.State.CHASE;
                }
            }
            //Raycast right edge of sight cone
            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, (transform.forward + transform.right).normalized, out hit, sightDistance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    player = hit.collider.gameObject;
                    state = EnemyController.State.CHASE;
                }
                if (hit.collider.gameObject.tag == "Projectile")
                {
                    player = hit.collider.gameObject;
                    state = EnemyController.State.CHASE;
                }
            }
            //Raycast left edge of sight cone
            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplyer, (transform.forward - transform.right).normalized, out hit, sightDistance))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    player = hit.collider.gameObject;
                    state = EnemyController.State.CHASE;
                }
                if (hit.collider.gameObject.tag == "Projectile")
                {
                    player = hit.collider.gameObject;
                    state = EnemyController.State.CHASE;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameOver = true;
        }
    }
}
