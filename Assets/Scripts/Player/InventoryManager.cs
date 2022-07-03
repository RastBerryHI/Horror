using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private ObservableCollection<Collactable> inventorySlots = new ObservableCollection<Collactable>();
    [SerializeField] private Transform inventrySlotsParent;
    [SerializeField] private uint avaliableSlots; 

    public ObservableCollection<Collactable> InventorySlots => inventorySlots;

    public delegate void ItemsRemovalEventHandler(int index);

    public event ItemsRemovalEventHandler OnItemsRemoval;

    public void AddToInventory(Collactable item)
    {
        if (avaliableSlots > 0 && item != null)
        {
            inventorySlots.Add(item);
            item.gameObject.SetActive(false);
            item.transform.SetParent(inventrySlotsParent);
            item.transform.position = inventrySlotsParent.transform.position;
            avaliableSlots--;
        }
        else
        {
            Debug.LogError("No Slots!");
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
            }
        }

        if (needed != null)
        {
            OnItemsRemoval(inventorySlots.IndexOf(needed));
            inventorySlots.Remove(needed);
            avaliableSlots++;
        }

        return needed;
    }
}
