using UnityEngine;

public class LockCylinder : MonoBehaviour, IInterractiveItem
{
    [SerializeField] private Disks diskID;
    private Lock lockParent;

    private void Awake()
    {
        lockParent = GetComponentInParent<Lock>();
    }

    public void OnIterraction(GameObject sender)
    {
        lockParent.Rotate(diskID);
    }
}
