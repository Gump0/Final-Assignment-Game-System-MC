using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_script : MonoBehaviour
{
    public int Main_Game;

    public void ChangeScene()
    {
        SceneManager.LoadScene(Main_Game);
    }
}
