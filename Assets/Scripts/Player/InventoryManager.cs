using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private HashSet<Collactable> inventorySlots = new HashSet<Collactable>();
    [SerializeField] private Transform inventrySlotsParent;
    [SerializeField] private uint avaliableSlots; 

    public void AddToInventory(Collactable item)
    {
        if (avaliableSlots > 0 && inventorySlots != null)
        {
            inventorySlots.Add(item);
            item.gameObject.SetActive(false);
            item.transform.parent = inventrySlotsParent;
            avaliableSlots--;
        }
    }
}
