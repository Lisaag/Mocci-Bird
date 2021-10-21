using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] GameObject front = null;
    [SerializeField] GameObject back = null;

    SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        spriteRenderer = front.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(Camera.main.WorldToScreenPoint(back.transform.localPosition).x <= Screen.width/2f)
        {
            front.transform.localPosition = back.transform.localPosition + new Vector3(32.82f, 0f);
            GameObject frontRef = front;
            front = back;
            back = frontRef;
            spriteRenderer = front.GetComponent<SpriteRenderer>();
        }
    }
}
