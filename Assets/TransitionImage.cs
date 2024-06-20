using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionImage : MonoBehaviour
{
    bool transitioning = false;
    Vector3 startPos1 = new Vector3(0, 0, 0);
    
    Vector3 startPos2 = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).position = transform.GetChild(1).position;
        startPos1 = transform.GetChild(1).position;
        startPos2 = transform.GetChild(2).position;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.GetChild(0).position = transform.GetChild(1).position;
        if (transitioning) {
            transform.GetChild(1).position = Vector3.Lerp(transform.GetChild(1).position, new Vector3(0, 0, 0), 0.1f);
            transform.GetChild(2).position = Vector3.Lerp(transform.GetChild(2).position, new Vector3(0, 0, 0), 0.1f);
        } else {
            transform.GetChild(1).position = Vector3.Lerp(transform.GetChild(1).position, startPos1, 0.1f);
            transform.GetChild(2).position = Vector3.Lerp(transform.GetChild(2).position, startPos2, 0.1f);
        }

    }

    public void SickTransition() {
        transitioning = true;
        StartCoroutine(Transition());
    }

    public IEnumerator Transition() {
        yield return new WaitForSeconds(1f);
        transform.GetChild(1).gameObject.SetActive(true);
        
        yield return new WaitForSeconds(.2f);
        transitioning = false;
        
    }
}
