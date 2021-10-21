using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerController : MonoBehaviour
{

    [SerializeField] GameObject skewerPrefab;
    [SerializeField] public int skewerCount = 5;
    [SerializeField] public float skewerDistance = 5f;
    [SerializeField] float maxHeight = 1f;
    [SerializeField] float minHeight = -1f;

    List<GameObject> allSkewers = new List<GameObject>();

    public static SkewerController instance = null;

    public GameObject backMostSkewer = null;


    private void Awake()
    {
        instance = this;

        for(int i = 0; i < skewerCount; i++)
        {
            GameObject o = Instantiate(skewerPrefab, new Vector2(skewerDistance * i, Random.Range(minHeight, maxHeight)), Quaternion.identity, transform);
            o.GetComponent<SkewerBehaviour>().skewerIndex = i;
            o.GetComponent<SkewerBehaviour>().AddDeathBodyToSkewer();
            allSkewers.Add(o);
        }

        backMostSkewer = allSkewers[skewerCount - 1];
    }

    void Start()
    {
        
    }

    void Update()
    {
       
    }
}
