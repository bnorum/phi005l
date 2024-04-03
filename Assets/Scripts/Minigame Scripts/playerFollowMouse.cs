using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerFollowMouse : MonoBehaviour
{

    public GameObject[] playerSprites = new GameObject[3];
    public GameObject[] zones = new GameObject[6];
    public int zoneActive = 0;
    GameObject aimAt;

    // Start is called before the first frame update
    void Start()
    {
        playerSprites[0].SetActive(false);
        playerSprites[1].SetActive(false);
        playerSprites[2].SetActive(true);
        aimAt = GameObject.Find("aimAt");
    }

    // Update is called once per frame
    void Update()
    {   
        for (int i = 0; i < zones.Length; i++)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (zones[i].GetComponent<Collider2D>().OverlapPoint(point)) {
                zoneActive = i;
            }
        }
        
        if (zoneActive == 0)
        {
            playerSprites[0].SetActive(false);
            playerSprites[1].SetActive(false);
            playerSprites[2].SetActive(true);
            playerSprites[2].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (zoneActive == 1)
        {
            playerSprites[0].SetActive(false);
            playerSprites[1].SetActive(true);
            playerSprites[2].SetActive(false);
            playerSprites[1].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (zoneActive == 2)
        {
            playerSprites[0].SetActive(true);
            playerSprites[1].SetActive(false);
            playerSprites[2].SetActive(false);
            playerSprites[0].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (zoneActive == 3)
        {
            playerSprites[0].SetActive(true);
            playerSprites[1].SetActive(false);
            playerSprites[2].SetActive(false);
            playerSprites[0].transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (zoneActive == 4)
        {
            playerSprites[0].SetActive(false);
            playerSprites[1].SetActive(true);
            playerSprites[2].SetActive(false);
            playerSprites[1].transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (zoneActive == 5)
        {
            playerSprites[0].SetActive(false);
            playerSprites[1].SetActive(false);
            playerSprites[2].SetActive(true);
            playerSprites[2].transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }
}
