using Unity.Cinemachine;
using UnityEngine;

public class OrbitalManager : MonoBehaviour
{
    private CinemachineOrbitalFollow orbitalFollow;
    private CinemachineInputAxisController controllerAxis;
    public float speed;
    public bool isOrbit;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orbitalFollow = GetComponent<CinemachineOrbitalFollow>();
        controllerAxis = GetComponent<CinemachineInputAxisController>();
        controllerAxis.enabled = false;
        orbitalFollow.HorizontalAxis.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isOrbit)
        {
            orbitalFollow.HorizontalAxis.Value += Time.deltaTime * speed;
        }
        
    }




}
