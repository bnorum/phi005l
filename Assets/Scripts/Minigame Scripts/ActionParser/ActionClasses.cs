using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class BeatDelayAction {
    public float beatDelay;
    public BeatDelayAction(float beatDelay) {
        this.beatDelay = beatDelay;
    }

}
public class Arrow : BeatDelayAction
{
    public int zone;
    public float beatstohit;
    public Arrow(int zone, float beatstohit, float beatDelay) : base(beatDelay)
    {
        this.zone = zone;
        this.beatstohit = beatstohit;
        this.beatDelay = beatDelay;
    }
}

public class Missile : BeatDelayAction
{
    public int zone;
    public float beatstohit;

    public int bounces;
    public Missile(int zone, float beatstohit, int bounces, float beatDelay) : base(beatDelay)
    {
        this.zone = zone;
        this.beatstohit = beatstohit;
        this.bounces = bounces;
        this.beatDelay = beatDelay;
    }
}
public class Laser : BeatDelayAction
{
    public int zone;
    public float warningduration;
    public Laser(int zone, float warningduration, float beatDelay) : base(beatDelay)
    {
        this.zone = zone;
        this.warningduration = warningduration;
        this.beatDelay = beatDelay;
    }
}

public class Text : BeatDelayAction
{
    public string text;

    public Text(string text, int beatDelay) : base(beatDelay)
    {
        this.text = text;
        this.beatDelay = beatDelay;
    }
}
