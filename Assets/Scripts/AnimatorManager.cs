using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public enum typeAnimator
    {
        RUN,
        IDLE,
        DEAD
    }




}

public class AnimatorSetup
{
    public AnimatorManager.typeAnimator type;
    public string trigger;
}
