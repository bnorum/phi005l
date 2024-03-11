using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.UI;

public class ScriptReader : MonoBehaviour
{
    public TextMeshProUGUI scriptReader;
    public Button decisionButton1;
    public TextMeshProUGUI decisionText1;
    public Button decisionButton2;
    public TextMeshProUGUI decisionText2;
    private string[] readableText = new string[18];
    private Dictionary<string, string> speakerColors = new Dictionary<string,string>()
        {
            {"Narrator", "#000fff"},
            {"Player", "#00ff00"},
            {"NPC", "#ff0000"}
        };
    
    public void WriteLine(ScriptLine nextLine) {
        for (int i = readableText.Length - 1; i > 0; i--)
        {
            readableText[i] = readableText[i - 1];
        }
        if(!speakerColors.ContainsKey(nextLine.Speaker))
        {
            speakerColors.Add(nextLine.Speaker, RandomNameColor());

        } 
        readableText[0] = "<color="+ speakerColors[nextLine.Speaker] + ">"  + nextLine.Speaker + "</color>: "+ nextLine.Content;
        scriptReader.text = string.Join("<br>", readableText.Reverse());
    }

    public void WriteDecisionLine(DecisionLine nextLine) {
        for (int i = readableText.Length - 1; i > 0; i--)
        {
            readableText[i] = readableText[i - 1];
        }
        if(!speakerColors.ContainsKey(nextLine.Speaker))
        {
            speakerColors.Add(nextLine.Speaker, RandomNameColor());

        } 
        readableText[0] = "<color="+ speakerColors[nextLine.Speaker] + ">"  + nextLine.Speaker + "</color>: "+ nextLine.Content;
        scriptReader.text = string.Join("<br>", readableText.Reverse());
        decisionText1.text = nextLine.D1;
        decisionText2.text = nextLine.D2;
    }

    public IEnumerator PlayScriptLines(ScriptLine[] scriptLines)
    {
        for (int i = 0; i < scriptLines.Length; i++)
        {
            if (scriptLines[i] is SkipTo)
            { 
                decisionButton1.gameObject.SetActive(false);
                decisionButton2.gameObject.SetActive(false);
                SkipTo skipTo = (SkipTo)scriptLines[i];
                i = (int)skipTo.JumpTo - 1; 
                continue;
            }

            else if (scriptLines[i] is DecisionLine)
            {
                decisionButton1.gameObject.SetActive(true);
                decisionButton2.gameObject.SetActive(true);
                DecisionLine decisionLine = (DecisionLine)scriptLines[i];
                WriteDecisionLine(decisionLine);
                var waitForButton = new WaitForUIButtons(decisionButton1, decisionButton2);
                yield return waitForButton.Reset();
                if (waitForButton.PressedButton == decisionButton1)
                {
                    i = (int)decisionLine.JumpTo1 - 1;
                }
                else
                {
                    i = (int)decisionLine.JumpTo2 - 1;
                }
            }

            else {
                decisionButton1.gameObject.SetActive(false);
                decisionButton2.gameObject.SetActive(false);
                WriteLine(scriptLines[i]); 
                yield return new WaitForSeconds(scriptLines[i].Delay);
            }
            
            
           
        } 
    }

    private string RandomNameColor() {
    string hexCode = "#";
    string characters = "6789ABCDEF";
    System.Random random = new System.Random();

    for (int i = 0; i < 6; i++)
    {
        hexCode += characters[random.Next(characters.Length)];
    }

    return hexCode;
    }

}
