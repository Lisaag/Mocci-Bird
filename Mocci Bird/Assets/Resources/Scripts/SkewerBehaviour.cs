using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] bool log = false;

    [SerializeField] GameObject top = null;
    [SerializeField] GameObject bottom = null;

    [SerializeField] MocciColors mocciColors;

    public int skewerIndex = 0;

    private void FixedUpdate()
    {
        if (!GameManager.isGameStarted) return;
        transform.localPosition += new Vector3(-speed * Time.deltaTime, 0f, 0f);

        if (Camera.main.WorldToScreenPoint(transform.localPosition).x <= -20f)
        {
            Vector2 newPos = SkewerController.instance.backMostSkewer.transform.localPosition + new Vector3(SkewerController.instance.skewerDistance, 0f);
            transform.localPosition = newPos;
            disableDeathBodies();
            skewerIndex += SkewerController.instance.skewerCount;
            AddDeathBodyToSkewer();
            SkewerController.instance.backMostSkewer = gameObject;
        }

    }

    private void disableDeathBodies()
    {
        foreach(Transform o in top.transform.GetChild(0))
        {
            o.gameObject.SetActive(false);
        }
        foreach (Transform o in bottom.transform.GetChild(0))
        {
            o.gameObject.SetActive(false);
        }
    }

    public void AddDeathBodyToSkewer()
    {
        if (GameManager.allDeaths[skewerIndex] != null)
        {
            int i = 0;
            foreach(MocciColor mc in GameManager.allDeaths[skewerIndex].topDeaths)
            {
                Debug.Log("test");
                SetDeadBody(top, i, mc);

                i++;
            }
            i = 0;
            foreach (MocciColor mc in GameManager.allDeaths[skewerIndex].bottomDeaths)
            {
                Debug.Log("test");
                SetDeadBody(bottom, i, mc);
                i++;
            }
        }
    }

    private void SetDeadBody(GameObject skewer, int mocciIndex, MocciColor color)
    {
        GameObject deadBody = skewer.transform.GetChild(0).GetChild(mocciIndex).gameObject;
        SpriteRenderer sr = deadBody.GetComponent<SpriteRenderer>();

        MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        sr.GetPropertyBlock(mpb);
        ColorProperties cp = mocciColors.GetColors(color);
        mpb.SetColor("_MainColor", cp.bodyColor);
        mpb.SetColor("_ShadowColor", cp.shadowColor);
        sr.SetPropertyBlock(mpb);

        deadBody.SetActive(true);
    }

    private void CheckOutsideScreen()
    {

    }
}
