using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    GameObject aimAt;
    GameObject player;
    GameObject blocker;
    Rigidbody2D rb;
    AudioSource AudioSource;
    public AudioClip damageClip;
    public AudioClip hitClip;
    bool touchingbarrier = false;
    public float beatstohit = 2;
    public int zone = 5;
    public float distanceToPlayer;
    float distanceOfPlayerToBlocker;
    float damageDistance;
    // Start is called before the first frame update
    void Start()
    {
        aimAt = GameObject.Find("aimAt");
        player = GameObject.Find("player");
        blocker = GameObject.Find("blocker");
        distanceOfPlayerToBlocker = UnityEngine.Vector3.Distance(player.transform.position, blocker.transform.position);
        rb = GetComponent<Rigidbody2D>();
        AudioSource = GameObject.Find("player").GetComponent<AudioSource>();
        distanceToPlayer = UnityEngine.Vector3.Distance(player.transform.position, transform.position) - distanceOfPlayerToBlocker;
        damageDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("blockerparent") != null)
            damageDistance = UnityEngine.Vector3.Distance(player.transform.position, transform.position) - distanceOfPlayerToBlocker;

        // Look at player
        UnityEngine.Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (!GameObject.Find("BadassBar").GetComponent<BadassManager>().stopped)
        {
            transform.rotation = UnityEngine.Quaternion.AngleAxis(angle+90, UnityEngine.Vector3.forward);
            UnityEngine.Vector3 rotationVector = transform.rotation.eulerAngles; // Convert Quaternion to Vector3
            transform.position += distanceToPlayer * -transform.up* Time.deltaTime/ (beatstohit*Conductor.instance.secPerBeat); // Multiply by rotationVector instead of transform.rotation    
        }

        if (touchingbarrier)
        {
            BadassManager bm = GameObject.Find("BadassBar").GetComponent<BadassManager>();
            bm.badass += 3;
            
            bm.streak += 1;
            if (bm.streak > bm.beststreak)
            {
                bm.beststreak += 1;
            }
            AudioSource.clip = hitClip;
            AudioSource.volume = 1f;
            AudioSource.Play();
            Destroy(gameObject);
            GameObject.Find("blocker").GetComponent<BarrierFollowMouse>().StartCoroutine("onHit");
        } else if (damageDistance < .05f && GameObject.Find("BadassBar").GetComponent<BadassManager>().hit) { //&& player.GetComponent<healthManager>().invincible) {
            Destroy(gameObject);
             AudioSource.clip = damageClip;
            AudioSource.volume = 0.5f;
            AudioSource.Play();
            GameObject.Find("BadassBar").GetComponent<BadassManager>().badass -= 15;
            //AudioSource.Play();
        } else if (damageDistance < .05f) {
            //player.GetComponent<healthManager>().damage(1);
            Destroy(gameObject);
            AudioSource.clip = damageClip; 
            
            AudioSource.volume = 0.5f;
            AudioSource.Play();
            //player.GetComponent<healthManager>().invincibility(2);
            BadassManager bm = GameObject.Find("BadassBar").GetComponent<BadassManager>();
            bm.badass -= 10;
            bm.streak = 0;
            bm.hit = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "barrier")
        {
            touchingbarrier = true;
            //UnityEngine.Debug.Log("touching barrier");
        }
    }
}
