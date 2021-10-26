using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPiece : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1.0f;
    void FixedUpdate()
    {
        if(GameManager.isGameStarted)
            transform.localPosition -= new Vector3(scrollSpeed * Time.deltaTime, 0f);
    }
}
