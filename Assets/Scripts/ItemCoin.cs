using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCoin : ItensBase
{
    //public SO_coins coin;
    [SerializeField]
    private int value;
    private GameManager manager;
    


    protected override void onColleted()
    {
        base.onColleted();
        manager.addCoins(value);
        //base.ColletedCoin();
        //ItemManager.Instance.addCoins(value);
    }
    
        
        
    


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindAnyObjectByType<GameManager>();
        //value = coin.coin;
    }


    private void OnDisable()
    {
        //Debug.Log("desligado");
        
        
    }


}


