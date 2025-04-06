using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCoin : ItensBase
{
    //public SO_coins coin;
    [SerializeField]
    private int value;
    [SerializeField]
    private float speed;
    private GameManager manager;
    private PlayerMove player;
    private bool magnetic = false;


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

    private void OnTriggerEnter(Collider other)
    {
                
        if (other.gameObject.CompareTag("Magnetic"))
        {
            
            player = GameObject.Find("Player").GetComponent<PlayerMove>();
            if (player != null)
            {
                magnetic = true;
            }
        }

    }


    private void Update()
    {
        if (magnetic)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }


}


