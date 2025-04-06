using System;
using UnityEngine;

public class SpinColletible : MonoBehaviour
{
    public float speedSpin = 200f;
    public GameObject spinObject;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinObject.transform.Rotate(Vector3.up * speedSpin * Time.deltaTime);
    }
}
