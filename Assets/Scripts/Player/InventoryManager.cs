using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Collactable> inventorySlots = new List<Collactable>();
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

    /// <summary>
    /// Can return null, handle it
    /// </summary>
    /// <param name="itemId">desired item id to get</param>
    /// <returns></returns>
    public Collactable GetFromInventory(int itemId)
    {
        Collactable needed = null;
        foreach(Collactable item in inventorySlots)
        {
            if (item.NameID == itemId)
            {
                needed = item;
                item.transform.parent = null;
                item.gameObject.SetActive(true);

                inventorySlots.Remove(item);
                avaliableSlots++;
            }
        }

        return needed;
    }
}
