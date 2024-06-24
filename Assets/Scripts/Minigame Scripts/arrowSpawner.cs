using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class arrowSpawner : MonoBehaviour
{
    
    public GameObject arrowPrefab;

    public GameObject missilePrefab;
    public Transform[] zones = new Transform[5];
    public GameObject[] warning = new GameObject[5];
    public BeatDelayAction[] beatDelayActions;
    public ActionParser actionParser;
    public TextMeshProUGUI actionText;
    public string textName;
    float currentbeat = 0;
    float savedbeat = 0;
    [SerializeField] int delayActionIndex = 0;
    
    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        actionParser = GetComponent<ActionParser>();
        actionText = GameObject.Find("ActionText").GetComponent<TextMeshProUGUI>();
        actionText.text = "";
        for (int i = 0; i < 5; i++)
        {
            zones[i] = transform.GetChild(i);
            warning[i] = zones[i].GetChild(0).gameObject;
            warning[i].SetActive(false);
        }

        beatDelayActions = actionParser.ParseText(actionParser.ReadString(textName + ".txt"));
        savedbeat = beatDelayActions[delayActionIndex].beatDelay;
    }
    // Update is called once per frame
    void Update()
    {
        
        currentbeat= Conductor.instance.songPositionInBeats;
        if(!GameObject.Find("BadassBar").GetComponent<BadassManager>().stopped && delayActionIndex < beatDelayActions.Length) 
        {
            
            if (beatDelayActions[delayActionIndex].GetType() == typeof(Arrow) && savedbeat <= currentbeat+2)
            {
                Arrow arrow = (Arrow) beatDelayActions[delayActionIndex];
                warning[arrow.zone-1].SetActive(true);
            }

            if (savedbeat <= currentbeat)
            {
                
                if (beatDelayActions[delayActionIndex].GetType() == typeof(Arrow))
                {
                    Arrow arrow = (Arrow) beatDelayActions[delayActionIndex];
                    spawnArrow(arrow.zone, arrow.beatstohit);
                    Arrow arrowcheck = (Arrow) beatDelayActions[delayActionIndex];
                    warning[arrowcheck.zone-1].SetActive(false);
                }
                
                if (beatDelayActions[delayActionIndex].GetType() == typeof(Missile))
                {
                    Missile missile = (Missile) beatDelayActions[delayActionIndex];
                    spawnMissile(missile.zone, missile.beatstohit, missile.bounces);
                    Missile arrowcheck = (Missile) beatDelayActions[delayActionIndex];
                    warning[arrowcheck.zone-1].SetActive(false);
                }

                if (beatDelayActions[delayActionIndex].GetType() == typeof(Text))
                {
                    Text text = (Text) beatDelayActions[delayActionIndex];
                    actionText.text = text.text;
                }
                
                
                delayActionIndex++;
                if (delayActionIndex < beatDelayActions.Length) savedbeat += beatDelayActions[delayActionIndex].beatDelay;
                
            }
        } 
        else if (delayActionIndex >= beatDelayActions.Length)
        {
          done = true;
        } 
    }

    public void spawnArrow(int zone, float speed = 1.0f)
    {
        GameObject arrow = Instantiate(arrowPrefab, zones[zone-1].transform.position, Quaternion.identity);
        arrow.GetComponent<arrowScript>().zone = zone-1;
        arrow.GetComponent<arrowScript>().beatstohit = speed;
    }
    
    public void spawnMissile(int zone, float speed = 1.0f, int bounces = 1)
    {
        GameObject arrow = Instantiate(missilePrefab, zones[zone-1].transform.position, Quaternion.identity);
        arrow.GetComponent<missileScript>().zone = zone-1;
        arrow.GetComponent<missileScript>().beatstohit = speed;
        arrow.GetComponent<missileScript>().bouncesRemaining = bounces;
    }
    
}
