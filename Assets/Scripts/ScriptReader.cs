using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.UI;
using System;

public class ScriptReader : MonoBehaviour
{
    public TextMeshProUGUI scriptReader;
    public Button decisionButton1;
    public TextMeshProUGUI decisionText1;
    public Button decisionButton2;
    public TextMeshProUGUI decisionText2;
    private string[] readableText = new string[50];
    public AudioSource aSource;

    public int currentIndex = 0;
    private Dictionary<string, string> speakerColors = new Dictionary<string,string>()
        {
            {characterDeets.pName, "#000fff"},
            {"mitchell.ae86", "#30332E"},
            {"Zanzibar", "#42f57b"},
            {"TOTALDESTRUCTION10000", "#F4442E"},
            {"Josh", "#020122"},
            {"pioneer", "#023Bf0"},
            {"developer", "#000fff"}

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
    public void WriteTitle(TitleLine title) {
        for (int i = readableText.Length - 1; i > 0; i--)
        {
            readableText[i] = readableText[i - 1];
        }
        readableText[0] = "<color=#8e918f>" + title.Title+ "</color>";
        scriptReader.text = string.Join("<br>", readableText.Reverse());
    }
    public void WriteConsole(ConsoleLine title) {
        for (int i = readableText.Length - 1; i > 0; i--)
        {
            readableText[i] = readableText[i - 1];
        }
        readableText[0] = "<color=#8e91FF>" + title.Title+ "</color>";
        scriptReader.text = string.Join("<br>", readableText.Reverse());
    }
    public void DecisionButtons(bool state) {
        decisionButton1.gameObject.SetActive(state);
        decisionButton2.gameObject.SetActive(state);
    }

    public IEnumerator PlayScriptLines(ScriptLine[] scriptLines) {
        for (int i = PlayerPrefs.GetInt("SavedLine"); i < scriptLines.Length; i++) {
            aSource.volume = UnityEngine.Random.Range(0.5f, 1.0f);

            aSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            aSource.Play();
            currentIndex = i;
            if (scriptLines[i] is Key) continue;

            else if (scriptLines[i] is SkipTo) { 
                DecisionButtons(false);
                SkipTo skipTo = (SkipTo)scriptLines[i];
                i = findKeyIndex(scriptLines, skipTo.JumpTo);
                continue;
            }
            else if (scriptLines[i] is TitleLine) {
                DecisionButtons(false);
                TitleLine titleLine = (TitleLine)scriptLines[i];
                WriteTitle(titleLine);
                yield return new WaitForSeconds(2.5f);
                readableText = new string[50];
            }
            else if (scriptLines[i] is ConsoleLine) {
                DecisionButtons(false);
                ConsoleLine consoleLine = (ConsoleLine)scriptLines[i];
                WriteConsole(consoleLine);
                yield return new WaitForSeconds(2.5f);
            }
            else if (scriptLines[i] is DecisionLine) {
                DecisionButtons(true);

                DecisionLine decisionLine = (DecisionLine)scriptLines[i];
                WriteDecisionLine(decisionLine);

                var waitForButton = new WaitForUIButtons(decisionButton1, decisionButton2);
                yield return waitForButton.Reset();

                if (waitForButton.PressedButton == decisionButton1) {
                    i = findKeyIndex(scriptLines, decisionLine.JumpTo1);
                    ScriptLine playerChoice = new ScriptLine(Speaker: characterDeets.pName, Content: decisionLine.D1);
                    WriteLine(playerChoice);
                    yield return new WaitForSeconds(playerChoice.Delay);
                } else {
                    i = findKeyIndex(scriptLines, decisionLine.JumpTo2);
                    ScriptLine playerChoice = new ScriptLine(Speaker: characterDeets.pName, Content: decisionLine.D2);
                    WriteLine(playerChoice);
                    yield return new WaitForSeconds(playerChoice.Delay);
                }
            }
            else {
                DecisionButtons(false);
                WriteLine(scriptLines[i]); 
                yield return new WaitForSeconds(scriptLines[i].Delay);
            }

        } 
    }

    private int findKeyIndex(ScriptLine[] scriptLines, string idToFind) {
        for (int i = 0; i < scriptLines.Length; i++)
        {
            if (scriptLines[i] is Key && ((Key)scriptLines[i]).ID == idToFind)
            {
                return i;
            }
        }
        return -1;
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
