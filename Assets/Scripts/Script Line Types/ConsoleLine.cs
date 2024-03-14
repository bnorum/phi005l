using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleLine : ScriptLine
{
   protected string title;
    public string Title {
        get { return title; }
        set { title = value; }
    }

    public ConsoleLine(string Title = "Title")
    {
        this.title = Title;
    }
}
