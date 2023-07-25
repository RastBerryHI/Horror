using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FurnDoorOpener : MonoBehaviour, IInterractiveItem, ISpookable
{
    [SerializeField] private bool canOpen = true;
    private Transform m_Transform;
    private float openingAngle = -90f;
    private bool isOpen = false;
    private float openingTime = 0.5f;
    private float closingAngle;

    private void Awake()
    {
        m_Transform = transform;
        if (name.EndsWith("R"))
        {
            openingAngle *= -1;
        }
        closingAngle = transform.localRotation.z;
    }

    public void AllowOpen() => canOpen = true;

    public void OnIterraction(GameObject sender)
    {
        if (!canOpen)
            return;
        if (!isOpen)
        {
            m_Transform.DOLocalRotate(new Vector3(0, openingAngle, 0), openingTime, RotateMode.Fast);
        }
        else
        {
            m_Transform.DOLocalRotate(new Vector3(0, closingAngle, 0), openingTime, RotateMode.Fast);
        }
        isOpen = !isOpen;
    }

    public void OnSpook(GameObject sender)
    {
        OnIterraction(sender);
    }
}
