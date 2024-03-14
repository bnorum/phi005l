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

    public TitleLine(string Title = "Title")
    {
        this.title = Title;
    }
}
