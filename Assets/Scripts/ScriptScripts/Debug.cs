using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour
{
    public void SpeedUp() {
        if (Time.timeScale == 5) Time.timeScale = 1;
        else Time.timeScale = 5;

    }

    public void QuitGame() {
        UnityEngine.Debug.Log("Quit Game");
        Application.Quit();
    }
}
