using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;

public class AfterImageFollow : MonoBehaviour
{
    public GameObject barrier;
    public ParticleSystem ps;
    public ParticleSystem.MainModule mainModule;
    // Start is called before the first frame update


    void Start()
    {
        barrier = GameObject.Find("blockspr");
        ps = GetComponent<ParticleSystem>();
        mainModule = ps.main; 
    }

    // Update is called once per frame
    void Update()
    {
        // Store the 'main' module in a variable
        mainModule.startRotation = -barrier.transform.rotation.eulerAngles.z * Mathf.Deg2Rad; // Modify the 'startRotation' property
        transform.position = barrier.transform.position + new Vector3(0f, 0, 0f);

    }
}
