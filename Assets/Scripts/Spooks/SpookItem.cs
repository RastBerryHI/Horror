using UnityEngine;

public class SpookItem : MonoBehaviour
{
    private Transform m_Transform;
    private IInterractiveItem interactive;    

    private void Awake()
    {
        m_Transform = transform;
        interactive = GetComponent<IInterractiveItem>();
    }

    [ContextMenu("DoSpook")]
    public void DoSpook()
    {
        interactive?.OnIterraction(gameObject);
    }
}
