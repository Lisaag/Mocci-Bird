using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPiece : MonoBehaviour
{

    void FixedUpdate()
    {
        if(GameManager.isGameStarted)
            transform.localPosition -= new Vector3(1f * Time.deltaTime, 0f);
    }
}
