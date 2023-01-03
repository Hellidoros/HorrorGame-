using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel("StartScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
