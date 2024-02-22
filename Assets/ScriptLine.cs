using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLine
{
    private string content;
    public string Content {
        get { return content; }
        set { content = value; }
    }
    private float delay;
    public float Delay {
        get { return delay; }
        set { delay = value; }
    }
    private string speaker;
    public string Speaker {
        get { return speaker; }
        set { speaker = value; }
    }

    public ScriptLine() {
        speaker = "Narrator";
        content = "This is a test.";
        delay = 1;
    }
    public ScriptLine(string Content, float Delay) {
        speaker = "NPC";
        content = Content;
        delay = Delay;
    }
    public ScriptLine(string Content) {
        speaker = "Narrator";
        content = Content;
        delay = 1;
    }
    public ScriptLine(string Speaker, string Content) {
        speaker = Speaker;
        content = Content;
        delay = 1;
    }
    public ScriptLine(string Speaker, string Content, float Delay) {
        speaker = Speaker;
        content = Content;
        delay = Delay;
    }
}
