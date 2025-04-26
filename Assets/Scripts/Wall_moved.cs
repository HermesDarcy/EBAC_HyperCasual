using System.Collections.Generic;
using UnityEngine;

public class Wall_moved : MonoBehaviour
{
    
    public List<Transform> points = new List<Transform>();
    public GameObject block;
    private int index = 0;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        block.transform.position = Vector3.Lerp(block.transform.position, points[index].transform.position, Time.deltaTime);
        if((block.transform.position - points[index].transform.position).magnitude <0.1f )
        {
            index++;
            if (index >= points.Count) index = 0;
        }
    }

    


}
