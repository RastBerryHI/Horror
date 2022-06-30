using UnityEngine;

/// <summary>
/// Base class for all interracrive items
/// </summary>
public abstract class InterractiveItem : MonoBehaviour
{
    public abstract void OnIterraction(GameObject sender);
}
