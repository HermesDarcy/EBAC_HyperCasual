using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItensBase : MonoBehaviour

{
    



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ColletedCoin();

        }
        

    }





    protected virtual void ColletedCoin()
    {
        
        
        gameObject.SetActive(false);
        onColleted();
    }


    protected virtual void onColleted()
    { 
        
            
    }





}
