using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WriteBeatMap : MonoBehaviour
{
    public string textname = "beat1";
    float currentbeat = 0;
    float savedbeat = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            WriteLine();
        }
    }

    public void WriteLine() {
        currentbeat = Conductor.instance.songPositionInBeats;

        string path = "Assets/Resources/"+ textname + ".txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("a " + (currentbeat - savedbeat) + " 1 1");
        writer.Close();
        savedbeat = currentbeat;
        
    }
}
