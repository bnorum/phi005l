using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1script : MonoBehaviour
{  
    public TextParser parser;
    public ScriptReader reader;
    void Start()
    {
        ScriptLine[] script = parser.ParseText(parser.ReadString("chapter1.bcn"));
        StartCoroutine(reader.PlayScriptLines(script));
    }
}
