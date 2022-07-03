using UnityEngine;

public class ArmsAnimations : MonoBehaviour
{
    [SerializeField] private Animator rightArm;
    [SerializeField] private Animator leftArm;

    private int drawOpenId = Animator.StringToHash("DrawOpen");

    public void RightArmOpenDraw()
    {
        rightArm.SetTrigger(drawOpenId);
    }
}
