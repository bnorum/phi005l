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
    public Transform[] zones = new Transform[5];
    public BeatDelayAction[] beatDelayActions;
    public ActionParser actionParser;
    public TextMeshProUGUI actionText;
    float currentbeat = 0;
    float savedbeat = 0;
    int delayActionIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        actionText = GameObject.Find("ActionText").GetComponent<TextMeshProUGUI>();
        actionParser = this.AddComponent<ActionParser>();
        for (int i = 0; i < 5; i++)
        {
            zones[i] = transform.GetChild(i);
        }

        beatDelayActions = actionParser.ParseText(actionParser.ReadString("test.txt"));
        savedbeat = beatDelayActions[delayActionIndex].beatDelay;
    }
    // Update is called once per frame
    void Update()
    {
        if (Conductor.instance.songPositionInBeats > currentbeat)
        {
            currentbeat++;
        }

        //UnityEngine.Debug.Log(currentbeat);
        
        if (savedbeat < currentbeat && delayActionIndex < beatDelayActions.Length)
        {
            
            if (beatDelayActions[delayActionIndex].GetType() == typeof(Arrow))
            {
                Arrow arrow = (Arrow) beatDelayActions[delayActionIndex];
                spawnArrow(arrow.zone, arrow.beatstohit);
            }
            if (beatDelayActions[delayActionIndex].GetType() == typeof(Text))
            {
                Text text = (Text) beatDelayActions[delayActionIndex];
                actionText.text = text.text;
            }
            delayActionIndex++;
            
            savedbeat += beatDelayActions[delayActionIndex].beatDelay;
            
        }
        
    }

    public void spawnArrow(int zone, float speed = 1.0f)
    {
        GameObject arrow = Instantiate(arrowPrefab, zones[zone-1].transform.position, Quaternion.identity);
        arrow.GetComponent<arrowScript>().zone = zone-1;
        arrow.GetComponent<arrowScript>().beatstohit = speed;
    }
    
}
