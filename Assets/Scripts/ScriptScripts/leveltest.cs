using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leveltest : MonoBehaviour
{  
    public TextParser parser;
    public ScriptReader reader;
    void Start()
    {
        ScriptLine[] script = parser.ParseText(parser.ReadString("test.bcn"));
        StartCoroutine(reader.PlayScriptLines(script));
    }
}
