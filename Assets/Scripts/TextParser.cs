using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextParser : MonoBehaviour
{

    public string ReadString(string path)
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        string saveit = reader.ReadToEnd();
        reader.Close();
        return saveit;
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
    
    public ScriptLine[] ParseText(string text)
        {
            //get array of strings that are separated by new line
            string[] lines = text.Split('\n');
            //define final array
            List<ScriptLine> readInText = new List<ScriptLine>();
            //iterator
            
            for (int x = 0; x < lines.Length; x++)
            {
                // Ignore lines starting with "//"
                if (string.IsNullOrWhiteSpace(lines[x]) || lines[x].Trim().StartsWith("//"))
                {
                    continue;
                }
                
                //reads stuff in quotes
                string extractedString = GetStringInQuotes(lines[x]);
                //splits line by spaces, to get first 2 queries
                string[] words = lines[x].Split(' ');
                
                ScriptLine scriptLine = new ScriptLine(words[0], float.Parse(words[1]), extractedString);
                readInText.Add(scriptLine);
            }
            return readInText.ToArray();
        }

}