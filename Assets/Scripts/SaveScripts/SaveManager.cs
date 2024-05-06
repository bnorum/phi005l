using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public void NewGame() {
        PlayerPrefs.SetInt("SavedLine", 0);
        ContinueGame();
    }

    public void SaveGame(int line) {
        PlayerPrefs.SetInt("SavedLine", line);
        
    }

    public void ContinueGame() {
        SceneManager.LoadScene(0);
    }

    public int LoadGame() {
        return PlayerPrefs.GetInt("SavedLine");
    }
}
