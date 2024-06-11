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
    private Vector3 moveTo;
    public void Start()
    {
       
    }
    public void startMinigame(float bpm, string textName) { //TODO: SET SONG
        //SCRIPT NAME, SONG NAME ARE THE SAME
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = false;
        Time.timeScale = 1;
        Transform moveToo = transform;
        moveToo.position = new Vector3(0, .45f, 0);
        minigame = Instantiate(minigamePrefab, moveToo);
        //minigame.transform.localScale = new Vector3(0, 0, 1);
        conductor = GameObject.Find("Conductor").GetComponent<Conductor>();
        //conductor.songBpm = bpm;
        arrowSpawner = GameObject.Find("arrowSpawner").GetComponent<arrowSpawner>();
        arrowSpawner.textName = textName;
        conductor.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/" + textName + ".mp3");
    }
    void Update() {
        if (minigame != null && GameObject.Find("arrowSpawner").GetComponent<arrowSpawner>().done) {
            Invoke("endMinigame", 2f);
        }
        
    }

    public void endMinigame() {
        Destroy(minigame);
        GameObject.Find("Viewport").GetComponent<Mask>().enabled = true;
    }
    public void scaleMinigame() {
        if (minigame.transform.localScale.x < 1) {
            minigame.transform.localScale = Vector3.Lerp(minigame.transform.localScale, new Vector3(1, 1, 1), Time.deltaTime);
        }
    }
    
}
