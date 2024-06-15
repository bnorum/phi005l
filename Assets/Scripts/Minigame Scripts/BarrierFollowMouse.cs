using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierFollowMouse : MonoBehaviour
{
    private Vector2 originalPosition;
    private Vector2 bouncePosition; 
    private bool hit = false;
    private GameObject[] barrierBlock = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.gameObject.transform.position;
        barrierBlock[0] = GameObject.Find("barrierblock");
        barrierBlock[1] = GameObject.Find("barrierblock2");
        barrierBlock[2] = GameObject.Find("barrierblock3");
        barrierBlock[3] = GameObject.Find("barrierblock4");
        barrierBlock[4] = GameObject.Find("barrierblock5");
        barrierBlock[5] = GameObject.Find("barrierblock6");
        for (int i = 0; i < barrierBlock.Length; i++) {
            if (barrierBlock[i] == null) {UnityEngine.Debug.Log("barrierblock" + i + " is null");}
            barrierBlock[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        bouncePosition = this.gameObject.transform.position - transform.right * 0.01f;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        if (!GameObject.Find("BadassBar").GetComponent<BadassManager>().stopped) {
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward); 
        }
        if (hit) {
            transform.position = Vector3.Lerp(transform.position, bouncePosition, 0.1f);
        }
        else {
            transform.position = Vector3.Lerp(transform.position, originalPosition, 0.1f);
        
        }
    }
    public IEnumerator onHit() {
        var choice = Random.Range(0, 6);
        barrierBlock[choice].SetActive(true);
        hit = true;
        yield return new WaitForSeconds(0.1f);
        hit = false;
        barrierBlock[choice].SetActive(false);
    }
}
