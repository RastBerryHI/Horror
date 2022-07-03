using UnityEngine;

public class ArmsAnimations : MonoBehaviour
{
    [SerializeField] private Animator rightArm;
    [SerializeField] private Animator leftArm;

    private int drawOpenId = Animator.StringToHash("DrawOpen");
    private int doorOpenId = Animator.StringToHash("DoorOpen");

    public void OnInterraction(RaycastHit hit)
    {   
        switch(hit.transform.tag)
        {
            case "Draw":
                rightArm.SetTrigger(drawOpenId);
                break;
            case "LittleDraw":
                rightArm.SetTrigger(drawOpenId);
                break;
            case "Door":
                rightArm.SetTrigger(doorOpenId);
                break;
        }
    }
}
