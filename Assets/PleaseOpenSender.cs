using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleaseOpenSender : MonoBehaviour, IInterractiveItem
{
    public void OnIterraction(GameObject sender)
    {
        GetComponentInParent<IInterractiveItem>().OnIterraction(sender);
    }
}
