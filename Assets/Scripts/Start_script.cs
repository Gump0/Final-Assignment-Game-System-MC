using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_script : MonoBehaviour
{
    //variable for main game screen
    public int Main_Game;
    //changes scene from start screen to main screen when user clicks
    public void ChangeScene()
    {
        SceneManager.LoadScene(Main_Game);
    }
}
