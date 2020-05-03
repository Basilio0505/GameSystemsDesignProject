using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    //public GameObject[] savepoints;
    public PlayerController player;

    public GameObject checkpoint0;

    public GameObject currentCheckpoint;

    void Start()
    {
        currentCheckpoint = checkpoint0;
    }

    //public void ClearSavepoints()
    //{
    //    foreach(GameObject s in savepoints)
    //    {
    //        s.GetComponent<MeshRenderer>().material.color = Color.blue;
    //    }
    //}

    public void SetCheckpoint(GameObject checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void WarpToCheckpoint()
    {
        Vector3 coords = new Vector3(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y, currentCheckpoint.transform.position.z);
        Debug.Log("WARP");
        Debug.Log("CHECK" + currentCheckpoint.transform.position);
        Debug.Log("PLAYER" + player.transform.position);
        player.movePlayer(coords);
        //player.transform.position = new Vector3(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y, currentCheckpoint.transform.position.z);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
