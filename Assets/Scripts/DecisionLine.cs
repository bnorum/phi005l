using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionLine : ScriptLine
{
    protected string d1;
    public string D1 {
        get { return d1; }
        set { d1 = value; }
    }
    protected string d2;
    public string D2 {
        get { return d2; }
        set { d2 = value; }
    }
    protected float jumpTo1;
    public float JumpTo1 {
        get { return jumpTo1; }
        set { jumpTo1 = value; }
    }
    protected float jumpTo2;
    public float JumpTo2 {
        get { return jumpTo2; }
        set { jumpTo2 = value; }
    }

    public DecisionLine(
            string Speaker = "Narrator",
            string Content = "This is a test.",
            float JumpTo1 = 0,
            float JumpTo2 = 0,
            string D1 = "Option 1",
            string D2 = "Option 2"
        )
    {
        this.content = Content;
        this.speaker = Speaker;
        this.jumpTo1 = JumpTo1;
        this.jumpTo2 = JumpTo2;
        this.d1 = D1;
        this.d2 = D2;
        ConvertName();
    }
}
