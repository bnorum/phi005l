using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTo : ScriptLine
{
    protected string jumpTo;
    public string JumpTo {
        get { return jumpTo; }
        set { jumpTo = value; }
    }

    public SkipTo(string JumpTo = "0")
    {
        this.jumpTo = JumpTo;
    }
}
