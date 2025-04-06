using UnityEngine;

public class Wall_efects : MonoBehaviour
{

    public GameObject effect;
    public GameObject block;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void invencibleImpact()
    {
        
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        effect.SetActive(true);
        block.SetActive(false);
        Invoke("myDestrutor", 3f);

    }


    public void myDestrutor()
    {
        Destroy(this.gameObject);
    }


}
