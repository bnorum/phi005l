using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    GameObject aimAt;
    GameObject player;
    GameObject blocker;
    Rigidbody2D rb;
    bool touchingbarrier = false;
    public float beatstohit = 2;
    public int zone = 5;
    public float distanceToPlayer;
    float distanceOfPlayerToBlocker;
    // Start is called before the first frame update
    void Start()
    {
        aimAt = GameObject.Find("aimAt");
        player = GameObject.Find("player");
        blocker = GameObject.Find("blocker");
        distanceOfPlayerToBlocker = UnityEngine.Vector3.Distance(player.transform.position, blocker.transform.position);
        rb = GetComponent<Rigidbody2D>();
        distanceToPlayer = UnityEngine.Vector3.Distance(player.transform.position, transform.position) - distanceOfPlayerToBlocker;
    }

    // Update is called once per frame
    void Update()
    {
        // Look at player
        UnityEngine.Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = UnityEngine.Quaternion.AngleAxis(angle+90, UnityEngine.Vector3.forward);
        UnityEngine.Vector3 rotationVector = transform.rotation.eulerAngles; // Convert Quaternion to Vector3
        transform.position += distanceToPlayer * -transform.up* Time.deltaTime/ (beatstohit*Conductor.instance.secPerBeat); // Multiply by rotationVector instead of transform.rotation
        if (touchingbarrier)
        {
            Destroy(gameObject);
        } else if (distanceToPlayer < 1) {
            player.GetComponent<healthManager>().damage(1);
            Destroy(gameObject);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "barrier")
        {
            touchingbarrier = true;
            UnityEngine.Debug.Log("touching barrier");
        }
    }
}
