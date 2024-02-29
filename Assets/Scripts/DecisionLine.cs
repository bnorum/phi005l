using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionLine : ScriptLine
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
    }   void ConvertName() {
        if (speaker == "b") {
            speaker = "Boss";
        }
        if (speaker == "c") {
            speaker = "Chuckles";
        }
    }
    public DecisionLine(string Speaker = "Narrator", float Delay = 1,string Content = "This is a test.")
    {
        this.content = Content;
        this.speaker = Speaker;
        this.delay = Delay;
        ConvertName();
    }


}
