using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollowMouse : MonoBehaviour
{

    public GameObject[] playerSprites = new GameObject[3];
    public GameObject damageSprite;
    public GameObject[] zones = new GameObject[6];
    public int zoneActive = 0;
    GameObject aimAt;
    public BadassManager badassManager;
    public int[] spriteOrder;
    // Start is called before the first frame update
    void Start()
    {
        spriteOrder = new int[] {2, 1, 0, 0, 1, 2};
        playerSprites[0].SetActive(false);
        playerSprites[1].SetActive(false);
        playerSprites[2].SetActive(true);
        aimAt = GameObject.Find("aimAt");
        badassManager = GameObject.Find("BadassBar").GetComponent<BadassManager>();
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
        if (!badassManager.stopped)
        {
            foreach (GameObject sprite in playerSprites)
            {
                sprite.SetActive(false);
            }
            damageSprite.SetActive(false);

            if (badassManager.hitTimer > 1.8f && badassManager.hitTimer < 2.0f) {
                if (zoneActive <= 2) {
                    damageSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else {
                    damageSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                damageSprite.SetActive(true);
            } else {
                playerSprites[spriteOrder[zoneActive]].SetActive(true);
                if (zoneActive<= 2) {
                    playerSprites[spriteOrder[zoneActive]].transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else {
                    playerSprites[spriteOrder[zoneActive]].transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
            
            
            
        }

    }
}
