using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    public GameObject[] savepoints;

    public void ClearSavepoints()
    {
        foreach(GameObject s in savepoints)
        {
            s.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
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
