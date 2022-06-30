using DG.Tweening;
using UnityEngine;

public class DoorRotator : InterractiveItem
{
    private Transform m_Transform;
    private Quaternion baseRotation;
    private bool hasRotated;

    private void Awake()
    {
        m_Transform = transform;
        baseRotation = m_Transform.rotation;
    }

    public override void OnIterraction(GameObject sender)
    {
        Vector3 senderPos = sender.transform.position;
        Vector3 doorPos = m_Transform.position;

        Vector3 dir = (senderPos - doorPos).normalized;

        Vector3 targetDir = new Vector3(dir.x, 0, 0);

        if (!hasRotated)
        {
            m_Transform.DORotateQuaternion(Quaternion.LookRotation (
                Vector3.RotateTowards (m_Transform.forward, targetDir, 500, 0.0F)
            ), 1); 
            hasRotated = !hasRotated;
        }
        else
        {
            m_Transform.DORotateQuaternion(baseRotation, 1);
            hasRotated = !hasRotated;
        }
    }
}
