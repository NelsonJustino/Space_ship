using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
   public void SinglePlayerMode()
    {
        SceneManager.LoadScene("SinglePlayer");
        Debug.Log("Single Player Mode = On");
    }

    public void MultiPlayerMode()
    {
        SceneManager.LoadScene("MultiPlayer");
        Debug.Log("Multi Player Mode = On");
    }
    public void TutorialMode()
    {
        SceneManager.LoadScene("Tutorial");
        Debug.Log("Tutorial Mode = On");
    }
}
