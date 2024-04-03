using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    GameObject aimAt;
    GameObject player;
    Rigidbody2D rb;
    public float speed = 4;
    int zone = 5;
    // Start is called before the first frame update
    void Start()
    {
        aimAt = GameObject.Find("aimAt");
        player = GameObject.Find("player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z+30);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < 1 && player.GetComponent<playerFollowMouse>().zoneActive == zone)
        {
            Destroy(gameObject);
        }
    }
}
