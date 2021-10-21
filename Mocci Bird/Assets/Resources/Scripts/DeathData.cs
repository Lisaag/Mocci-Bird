using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathData
{
    const int maxBodyCount = 3;

    public int index;
    public FixedSizedQueue<MocciColor> topDeaths = new FixedSizedQueue<MocciColor>(maxBodyCount);
    public FixedSizedQueue<MocciColor> bottomDeaths = new FixedSizedQueue<MocciColor>(maxBodyCount);


    public DeathData(int index, DeathCause deathCause, MocciColor mocciColor)
    {
        this.index = index;
        if (deathCause == DeathCause.Top) topDeaths.Enqueue(mocciColor);
        else if (deathCause == DeathCause.Bottom) bottomDeaths.Enqueue(mocciColor);
        Debug.Log("new deathdata created");
    }
}

public enum DeathCause
{
    Fall,
    Top,
    Bottom
}

public enum MocciColor
{
    Purple,
    Pink,
    White,
    Green
}
