using DG.Tweening;
using UnityEngine;

public class DoorRotator : InterractiveItem
{
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

    public override void OnIterraction(GameObject sender)
    {
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
            m_Transform.DORotateQuaternion(baseRotation, 1);
            hasRotated = !hasRotated;
        }
    }
}
