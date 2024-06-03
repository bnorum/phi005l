using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BadassManager : MonoBehaviour
{
    public int badass = 100;
    public int maxBadass = 100;
    public int streak = 0;
    public int beststreak = 0;
    public int badassLossPerSecond = 1;
    public GameObject badassBar;
    public GameObject streakBar;
    public GameObject bestStreakBar;
    public float timer = 1;
    public int totalbullets = 1;
    public bool hit = false;
    public float hitTimer = 2;
    public bool stopped = false;
    public AudioSource gameOver;
    void Start()
    {
        badassBar = GameObject.Find("BadassBar");
        streakBar = GameObject.Find("StreakBar");
        bestStreakBar = GameObject.Find("BestStreakBar");
        gameOver = GetComponent<AudioSource>();

    }

    void Update ()
    {
        
        if (hitTimer <= 0) {
            hit = false;
            hitTimer = 2;
        }
        if (hit == true) {
            hitTimer -= Time.deltaTime;
            
        } 
        if (timer <= 0)
        {
            badass -= badassLossPerSecond;
            timer = 1;
        }
        timer-= Time.deltaTime;

        totalbullets = GameObject.Find("arrowSpawner").GetComponent<arrowSpawner>().beatDelayActions.Count();
        badassBar.transform.localScale = new Vector2((float)badass / maxBadass, 1);
        streakBar.transform.localScale = new Vector2((float)streak / totalbullets, 1);
        bestStreakBar.transform.localScale = new Vector2((float)beststreak / totalbullets, 1);

        if (badass > maxBadass)
        {
            badass = maxBadass;
        }

        if (badass <= 0)
        {
            stopped = true;
            //if (GameObject.Find("GameOver") != null)
            //{
            //    GameObject.Find("GameOver").transform.GetChild(0).gameObject.SetActive(true);
            //}
            gameOver.Play();
        } else {
            stopped = false;
        }


        //debug cheat
        if (Input.GetKeyDown(KeyCode.P))
        {
            badass += 10;
        }
    }
}
