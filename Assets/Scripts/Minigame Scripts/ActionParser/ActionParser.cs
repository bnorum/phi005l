using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ActionParser : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public float bpm;
    public string ReadString(string path)
    {
        // Check if the file exists at the specified location
        if (File.Exists(path))
        {
            // Read the text from the file
            StreamReader reader = new StreamReader(path);
            string saveit = reader.ReadToEnd();
            reader.Close();
            return saveit;
        }
        else
        {
            // Read the text from the file in the assets/resources folder
            StreamReader reader = new StreamReader("Assets/Resources/GameMaps/" + path);
            string saveit = reader.ReadToEnd();
            return saveit;
        }
    }

    public BeatDelayAction[] ParseText(string text) {

        string[] lines = text.Split('\n');
        List<BeatDelayAction> actions = new List<BeatDelayAction>();
        foreach (string line in lines) {
            string[] parts = line.Split(' ');
            if (parts[0] == "bpm") {
                GameObject.Find("Conductor").GetComponent<Conductor>().songBpm = float.Parse(parts[1]);

            }
            if (parts[0] == "a") {
                BeatDelayAction action = new Arrow(zone: int.Parse(parts[3]), beatstohit: float.Parse(parts[2]), beatDelay: float.Parse(parts[1]));
                actions.Add(action);
            }
            if (parts[0] == "t") {
                
            string textInQuotes = GetStringInQuotes(line);
            BeatDelayAction action = new Text(text: textInQuotes, beatDelay: int.Parse(parts[1]));
            actions.Add(action);
            }
            if (parts[0] == "m") {
                
            BeatDelayAction action = new Missile(zone: int.Parse(parts[4]), beatstohit: float.Parse(parts[2]), bounces: int.Parse(parts[3]), beatDelay: float.Parse(parts[1]));
            actions.Add(action);
            }
            if (parts[0] == "l") {
                
            BeatDelayAction action = new Laser(zone: int.Parse(parts[2]), warningduration: 3, beatDelay: float.Parse(parts[1]));
            actions.Add(action);
            }
        }
        return actions.ToArray();
    }

    public string GetStringInQuotes(string text)
    {
        string result = "";
        int startIndex = text.IndexOf('"');
        int endIndex = text.LastIndexOf('"');
        if (startIndex != -1 && endIndex != -1 && startIndex < endIndex)
        {
            result = text.Substring(startIndex + 1, endIndex - startIndex - 1);
        }
        return result;
    }
}
