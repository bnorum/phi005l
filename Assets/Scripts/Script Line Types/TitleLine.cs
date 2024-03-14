using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLine : ScriptLine
{
    protected string title;
    public string Title {
        get { return title; }
        set { title = value; }
    }
    protected bool clear;
    public bool Clear {
        get { return clear; }
        set { Clear = value; }
    }

    public TitleLine(string Title = "Title", bool Clear = true)
    {
        this.title = Title;
        this.clear = Clear;
    }
}
