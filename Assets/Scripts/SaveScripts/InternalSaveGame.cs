using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalSaveGame : MonoBehaviour
{
    public SaveManager saveManager;
    public ScriptReader scriptReader;

    public void SaveGame()
    {
        saveManager.SaveGame(scriptReader.currentIndex);
    }
}
