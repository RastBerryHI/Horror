using DG.Tweening;
using UnityEngine;

public class DoorRotator : MonoBehaviour, IInterractiveItem, ISpookable
{
    [SerializeField] private bool canOpen = true;
    private Transform m_Transform;
    private Quaternion baseRotation;
    private Vector3 openingVector;
    private Vector3 positiveVector;
    private bool hasRotated;

    private void Awake()
    {
        m_Transform = transform;
        baseRotation = m_Transform.rotation;

        openingVector = m_Transform.right * 90;
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Door")
        {
            ReturnToBaseRotation();
        }
    }

    private void ReturnToBaseRotation()
    {
        m_Transform.DORotateQuaternion(baseRotation, 1);
        hasRotated = !hasRotated;
    }

    public void AllowOpen() => canOpen = true;

    public void OnIterraction(GameObject sender)
    {
        if (!canOpen)
        {
            return;
        }

        Vector3 invertedLook = -sender.transform.forward;
        Vector3 euler;

        if (!hasRotated)
        {
            // Eboochiy kosteel            
            if ( Mathf.Abs( invertedLook.x ) > 0.1f)
            {
                // x is positive or not
                if (invertedLook.x > 0)
                {
                    euler = Quaternion.LookRotation(openingVector).eulerAngles;
                }
                else
                {
                    euler = Quaternion.LookRotation(-openingVector).eulerAngles;
                }
            }
            else
            {
                if (invertedLook.z < 0)
                {
                    euler = Quaternion.LookRotation(openingVector).eulerAngles;
                }
                else
                {
                    euler = Quaternion.LookRotation(-openingVector).eulerAngles;
                }
            }

            m_Transform.DOLocalRotate(euler, 1); 
            hasRotated = !hasRotated;
        }
        else
        {
            ReturnToBaseRotation();
        }
    }

    public void OnSpook(GameObject sender)
    {
        OnIterraction(sender);
    }
}
