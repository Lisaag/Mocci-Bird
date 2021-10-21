using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MocciColors", menuName = "ScriptableObjects/MocciColors", order = 1)]
public class MocciColors : ScriptableObject
{
    [SerializeField] public List<ColorProperties> allColorPresets = new List<ColorProperties>();

    public ColorProperties GetColors(MocciColor mocciColor)
    {
        foreach(ColorProperties c in allColorPresets)
        {
            if(c.color == mocciColor)
            {
                return c;
            }
        }
        return null;
    }
}

[Serializable]
public class ColorProperties
{
    [SerializeField] public MocciColor color;
    [SerializeField] public Color bodyColor;
    [SerializeField] public Color shadowColor;
}
