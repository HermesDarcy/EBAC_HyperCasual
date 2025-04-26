using UnityEngine;

public class Wall_efects : MonoBehaviour
{

    public GameObject effect;
    public GameObject block;
    
    
    


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
