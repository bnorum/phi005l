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

    public string GetStringInQuotesForDecision(string text)
    {
        string result = "";
        int startIndex = text.IndexOf('"');
        int nextIndex = text.IndexOf('"', text.IndexOf('"') + 1);
        if (startIndex != -1 && nextIndex != -1 && startIndex < nextIndex)
        {
            result = text.Substring(startIndex + 1, nextIndex - startIndex - 1);
        }
        return result;
    }

    public string[] GetDecisions(string text)
    {
        string[] results = new string[2];
        int startIndex = text.IndexOf('|');
        int nextIndex = text.IndexOf('|', text.IndexOf('|') + 1);
        if (startIndex != -1 && nextIndex != -1 && startIndex < nextIndex)
        {
            results[0] = text.Substring(startIndex + 1, nextIndex - startIndex - 1);
            results[1] = text.Substring(nextIndex + 1);
        }
        return results;
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

                //key foxtrot
                if (lines[x].Trim().StartsWith("key"))
                {
                    string[] kWords = lines[x].Split(' ');
                    Key key = new Key(ID: GetStringInQuotes(lines[x]));
                    readInText.Add(key);
                }

                //skip foxtrot
                else if (lines[x].Trim().StartsWith("skip")) {
                    string[] sWords = lines[x].Split(' ');
                    SkipTo skipTo = new SkipTo(JumpTo:GetStringInQuotes(lines[x]));
                    readInText.Add(skipTo);
                }

                
                // ddd speaker whiskey tango "hello" | Option 1 | Option 2
                else if (lines[x].Trim().StartsWith("ddd")) {
                    string[] dWords = lines[x].Split(' ');
                    string dExtractedString = GetStringInQuotesForDecision(lines[x]);
                    DecisionLine decisionLine = new DecisionLine(
                        dWords[1], //speaker
                        dExtractedString, //content
                        dWords[2], //jump1
                        dWords[3], //jump2
                        GetDecisions(lines[x])[0], //first decision 
                        GetDecisions(lines[x])[1] //second decision
                    );
                    readInText.Add(decisionLine);
                } else {
                    //reads stuff in quotes
                    string extractedString = GetStringInQuotes(lines[x]);
                    //splits line by spaces, to get first 2 queries
                    string[] words = lines[x].Split(' ');
                    
                    ScriptLine scriptLine = new ScriptLine(
                        words[0], 
                        float.Parse(words[1]), 
                        extractedString
                    );
                    readInText.Add(scriptLine);
                }
            }
            return readInText.ToArray();
        }

}