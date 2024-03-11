using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTo : ScriptLine
{
    protected float jumpTo;
    public float JumpTo {
        get { return jumpTo; }
        set { jumpTo = value; }
    }

    public SkipTo(float JumpTo = 0)
    {
        this.jumpTo = JumpTo;
    }
}
