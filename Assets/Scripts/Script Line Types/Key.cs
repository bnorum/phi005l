using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ScriptLine
{
    protected string id;
    public string ID {
        get { return id; }
        set { id = value; }
    }

    public Key(string ID = "baseid")
    {
        this.id = ID;
    }
}
