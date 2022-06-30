using UnityEngine;

public class DoorRotator : InterractiveItem
{
    private Transform m_Transform;

    private void Awake()
    {
        m_Transform = transform;
    }

    public override void OnIterraction(GameObject sender)
    {
        Vector3 senderPos = sender.transform.position;
        Vector3 doorPos = m_Transform.position;

        Vector3 dir = (senderPos - doorPos).normalized;

        Debug.Log(dir);
    }
}
