using System.Collections.Generic;
using UnityEngine;

public class LineTracer : MonoBehaviour
{
    public LineRenderer lr;
    public List<Transform> stake = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //lr = GetComponent<LineRenderer>();
        lr.positionCount = stake.Count;
        
    }

    private void Update()
    {
        LineInTracer();
    }

    private void LineInTracer()
    {
        for (int i = 0; i < stake.Count; i++)
        {
            lr.SetPosition(i, stake[i].localPosition);
        }
    }

}
