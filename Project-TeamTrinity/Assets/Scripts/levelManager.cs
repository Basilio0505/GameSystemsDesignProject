using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    //public GameObject[] savepoints;
    public PlayerController player;

    public Text objectiveText;
    private int objectiveCounter;

    public GameObject checkpoint0;
    public GameObject currentCheckpoint;

    void Start()
    {
        currentCheckpoint = checkpoint0;
        objectiveCounter = 0;
    }

    //public void ClearSavepoints()
    //{
    //    foreach(GameObject s in savepoints)
    //    {
    //        s.GetComponent<MeshRenderer>().material.color = Color.blue;
    //    }
    //}

    public void NewObjective()
    {
        objectiveCounter += 1;
        if (objectiveCounter == 1)
        {
            objectiveText.text = "Find the YELLLOW Button to open Exhibit Doors (YELLOW Doors).";
        }
        else if (objectiveCounter == 2)
        {
            objectiveText.text = "Find the RED Button in the Exhibit Room to deactivate lasers.";
        }
        else if (objectiveCounter == 3)
        {
            objectiveText.text = "Find the Green Button in the Gallery Room to open the vault.";
        }
        else if (objectiveCounter == 4)
        {
            objectiveText.text = "Grab the Trophy and make your escape out the EXIT!";
        }
    }

    //Used to set new checkpoint on each gate button press
    public void SetCheckpoint(GameObject checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public void WarpToCheckpoint()
    {
        Vector3 coords = new Vector3(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y, currentCheckpoint.transform.position.z);
        player.movePlayer(coords);
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
