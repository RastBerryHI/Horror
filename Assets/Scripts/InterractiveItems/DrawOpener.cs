using UnityEngine;
using DG.Tweening;

public class DrawOpener : MonoBehaviour, IInterractiveItem
{
    private bool isOpen = false;
    private float openingTime = 0.5f;
    private Transform m_Transform;
    private float openingDist;
    private float startingPoint;

    private void Awake()
    {
        m_Transform = transform;
        openingDist = GetComponent<Collider>().bounds.size.z * 2 / 3;
        startingPoint = transform.localPosition.z;
    }

    public void OnIterraction(GameObject sender)
    {
        if (!isOpen)
        {
            m_Transform.DOLocalMoveZ(openingDist,openingTime, false);
        }
        else
        {
            m_Transform.DOLocalMoveZ(startingPoint, openingDist, false);
        }
        isOpen = !isOpen;
    }

}
