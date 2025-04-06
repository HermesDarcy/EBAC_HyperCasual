using System.Collections;
using UnityEngine;

public class PowerUpsBase : ItensBase
{

    public float newSpeed, isTime;
    public float slowSpeed;
    public float bigScale, smallScale;
    public bool invencivel;

    private PlayerMove player;

    public enum powerUp
    {
        Speed,
        Invencivel,
        Big,
        Small,
        Magnetic,
        Slow,
        Jump
    
    
    }

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();   
    }


    public powerUp myPower;


    protected override void onColleted()
    {
        base.onColleted();
        Debug.Log(myPower.ToString());
        switch (myPower)
        {
            case powerUp.Speed:
                player.powerUpSpeed(newSpeed,isTime);
                break;
            case powerUp.Invencivel:
                player.PowerUpNoDeath(isTime);
                break;
            case powerUp.Big:
                player.doNewScale(bigScale, isTime);
                break;
            case powerUp.Slow:
                player.powerUpSpeed(slowSpeed, isTime);
                break;
            case powerUp.Small:
                player.doNewScale(smallScale, isTime);
                break;
            case powerUp.Magnetic:
                player.PowerUpMagnetic(isTime);
                break;
            case powerUp.Jump:
                player.PowerUpJump();
            break;
        }
            
        
        
    }

    
        
    



}
