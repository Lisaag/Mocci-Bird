using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] SpriteRenderer maskSpriteRenderer = null;
    [SerializeField] MocciColors mocciColors = null;

    public MocciColor currentColor = default;

    private void Start()
    {
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        int index = Random.Range(1, mocciColors.allColorPresets.Count);

        currentColor = mocciColors.allColorPresets[index].color;

        Debug.Log("changing color!!");

        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        maskSpriteRenderer.GetPropertyBlock(mpb);
        mpb.SetColor("_MainColor", mocciColors.allColorPresets[index].bodyColor);
        mpb.SetColor("_ShadowColor", mocciColors.allColorPresets[index].shadowColor);
        maskSpriteRenderer.SetPropertyBlock(mpb);
    }
}
