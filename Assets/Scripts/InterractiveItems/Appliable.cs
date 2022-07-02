using UnityEngine;

public class Appliable : MonoBehaviour
{
    //private Animator anim;
    private Transform m_Transform;
    private int applyId = Animator.StringToHash("Apply");

    public Transform Mtransform => m_Transform;
    private void Awake()
    {
        //anim = GetComponent<Animator>();
        m_Transform = transform;
    }

    public void Apply()
    {
        //anim.SetTrigger(applyId); 
    }
}
