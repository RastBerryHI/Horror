using UnityEngine;

public class SpookItem : MonoBehaviour
{
    private Transform m_Transform;
    private ISpookable interactive;    

    private void Awake()
    {
        m_Transform = transform;
        interactive = GetComponent<ISpookable>();
    }

    [ContextMenu("DoSpook")]
    public void DoSpook()
    {
        interactive?.OnSpook(gameObject);
    }
}
