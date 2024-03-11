using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLine
{
    protected string content;
    public string Content {
        get { return content; }
        set { content = value; }
    }
    protected float delay;
    public float Delay {
        get { return delay; }
        set { delay = value; }
    }
    protected string speaker;
    public string Speaker {
        get { return speaker; }
        set { speaker = value; }
    }

    protected void ConvertName() {
        if (speaker == "b") {
            speaker = "Boss";
        }
        if (speaker == "c") {
            speaker = "Chuckles";
        }

    }
    public ScriptLine(string Speaker = "Narrator", float Delay = 1,string Content = "This is a test.")
    {
        this.content = Content;
        this.speaker = Speaker;
        this.delay = Delay;
        ConvertName();
    }


    
}
