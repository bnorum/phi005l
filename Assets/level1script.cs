using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1script : MonoBehaviour
{
    private ScriptReader reader;
    public ScriptLine[] script = new ScriptLine[14] {
        new ScriptLine("You wake up in a dark room."),
        new ScriptLine("You can't remember how you got here.", 5),
        new ScriptLine("You can't remember anything."),
        new ScriptLine("You can't remember your name."),
        new ScriptLine("You can't remember anything."),
        new ScriptLine("You can't remember your name."),
        new ScriptLine("You can't remember anything."),
        new ScriptLine("You can't remember your name."),
        new ScriptLine("You can't remember anything."),
        new ScriptLine("You can't remember your name."),
        new ScriptLine("You can't remember anything."),
        new ScriptLine("You can't remember your name."),
        new ScriptLine("You can't remember anything."),
        new ScriptLine("You can't remember your name.")
    };
    void Start()
    {
        reader = GetComponent<ScriptReader>();
        StartCoroutine(reader.PlayScriptLines(script));
    }
}
