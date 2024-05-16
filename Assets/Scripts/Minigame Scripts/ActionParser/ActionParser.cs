using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ActionParser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
            StreamReader reader = new StreamReader("Assets/Resources/" + path);
            string saveit = reader.ReadToEnd();
            return saveit;
        }
    }

    public BeatDelayAction[] ParseText(string text) {

        string[] lines = text.Split('\n');
        List<BeatDelayAction> actions = new List<BeatDelayAction>();
        foreach (string line in lines) {
            string[] parts = line.Split(' ');
            if (parts[0] == "a") {
                BeatDelayAction action = new Arrow(zone: int.Parse(parts[3]), beatstohit: float.Parse(parts[2]), beatDelay: int.Parse(parts[1]));
                actions.Add(action);
            }
            if (parts[0] == "t") {
                
            string textInQuotes = GetStringInQuotes(line);
            BeatDelayAction action = new Text(text: textInQuotes, beatDelay: int.Parse(parts[1]));
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
