using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public GameObject minigamePrefab;
    GameObject minigame;
    public Conductor conductor;
    public arrowSpawner arrowSpawner;
    bool minigameLeaving = false;
    public void Start()
    {
       
    }
    
    void Update() {
        if (minigame != null && GameObject.Find("arrowSpawner").GetComponent<arrowSpawner>().done && !minigameLeaving) {
            Invoke("endMinigame", 2f);
            minigameLeaving = true;
        }

        
    }

    public bool startMinigame(string textName) { //TODO: SET SONG
        //SCRIPT NAME, SONG NAME ARE THE SAME
        if (ifMinigameExists(textName)) {
            GameObject.Find("Viewport").GetComponent<Mask>().enabled = false;
            Time.timeScale = 1;
            Transform moveToo = transform;
            moveToo.position = new Vector3(0, .45f, 0);
            minigame = Instantiate(minigamePrefab, moveToo);
            minigame.transform.localScale = new Vector3(0, 0, 1);
            
            Invoke("showBlocker", 1.4f);
            StartCoroutine(scaleMinigame(true));
            conductor = GameObject.Find("Conductor").GetComponent<Conductor>();
            conductor.songBpm = GameObject.Find("arrowSpawner").GetComponent<ActionParser>().bpm;
            arrowSpawner = GameObject.Find("arrowSpawner").GetComponent<arrowSpawner>();
            arrowSpawner.textName = textName;
            string audioPath = "Assets/Resources/Sounds/" + textName + ".mp3";
            AudioClip audioClip = UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>(audioPath);
            conductor.GetComponent<AudioSource>().clip = audioClip;
            return true;
        }
        return false;
    }

    public void endMinigame() {
        StartCoroutine(scaleMinigame(false));
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = true;
    }

    public bool ifMinigameExists(string name) {
        return UnityEditor.AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Resources/Sounds/" + name + ".mp3") != null && UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Resources/GameMaps/" + name + ".txt") != null;
        
    }

    public void showBlocker() {
        GameObject.Find("blockerparent").transform.GetChild(0).gameObject.SetActive(true);
    }
    public void hideBlocker() {
        if (GameObject.Find("blockerparent") != null)
            GameObject.Find("blockerparent").transform.GetChild(0).gameObject.SetActive(false);
    }
    public IEnumerator scaleMinigame(bool up = true) {
        if (up) {
            for (int i = 0; i < 6; i++) {
                minigame.transform.localScale = new Vector3(i / 5f, i / 5f, 1);
                yield return new WaitForSeconds(.2f);
            }
        }
        else {
            hideBlocker();
            GameObject.Find("Conductor").GetComponent<Conductor>().StartCoroutine(GameObject.Find("Conductor").GetComponent<Conductor>().fadeOut());
            for (int i = 5; i >= 0; i--) {
                minigame.transform.localScale = new Vector3(i / 5f, i / 5f, 1);
                yield return new WaitForSeconds(.2f);
            }
            Destroy(minigame);
        }
    }
    
}
