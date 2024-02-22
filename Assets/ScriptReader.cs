using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;

public class ScriptReader : MonoBehaviour
{
    public TextMeshProUGUI scriptReader;
    private string[] readableText = new string[14];
    private Dictionary<string, string> speakerColors;

    void Start()
    {
        speakerColors = new Dictionary<string,string>()
        {
            {"Narrator", "#000fff"},
            {"Player", "#00ff00"},
            {"NPC", "#ff0000"}
        };
    }

    public void WriteLine(ScriptLine nextLine) {
        for (int i = readableText.Length - 1; i > 0; i--)
        {
            readableText[i] = readableText[i - 1];
        }
        readableText[0] = "<color="+ speakerColors[nextLine.Speaker] + ">" + nextLine.Speaker + "</color>: "+ nextLine.Content;
        scriptReader.text = string.Join("<br>", readableText.Reverse());
    }

    

    public IEnumerator PlayScriptLines(ScriptLine[] scriptLines)
    {
        foreach (ScriptLine scriptLine in scriptLines)
        {
            WriteLine(scriptLine);
            yield return new WaitForSeconds(scriptLine.Delay);
        }
        
    }

    
}
