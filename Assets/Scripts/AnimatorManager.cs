using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    public Animator animator;
    public List<AnimatorSetup> animSet;
    
    
    
    public enum typeAnimator
    {
        RUN,
        IDLE,
        DEAD
    }


    public void OnPlay(typeAnimator type, float sp=1f)
    {
        foreach (AnimatorSetup i in animSet)
        {
            if(i.type == type)
            {
                animator.SetTrigger(i.trigger);
                animator.speed = i.speed * sp;
                break;
            }
        }
    }


    private void Update()
    {
        // teste teclado

        if (Input.GetKeyDown(KeyCode.Alpha3)) // tecla 3
        {
            OnPlay(typeAnimator.IDLE);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1)) // 1
        {
            OnPlay(typeAnimator.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2
        {
            OnPlay(typeAnimator.DEAD);
        }

    }



}



[System.Serializable]
public class AnimatorSetup
{
    public AnimatorManager.typeAnimator type;
    public string trigger;
    public float speed;
}
