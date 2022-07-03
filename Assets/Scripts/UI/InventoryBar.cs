using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Specialized;

public class InventoryBar : MonoBehaviour
{
    [SerializeField] private List<Button> inventorySlots = new List<Button>(6);
    [SerializeField] private InventoryManager inventoryManager;

    private int operationalIndex;

    private void Awake()
    {
        inventoryManager.InventorySlots.CollectionChanged += ManageItems;
        inventoryManager.OnItemsRemoval += ItemsRemoval_GetIndex;
    }

    private void ManageItems(object sender, NotifyCollectionChangedEventArgs e)
    {
        Button button;
        RawImage img;
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            operationalIndex = inventoryManager.InventorySlots.Count - 1;
            button = inventorySlots[operationalIndex];
            img = button.transform.GetChild(0).GetComponent<RawImage>();
            img.color = new Color(img.color.r, img.color.g, img.color.b, 255);
            img.texture = inventoryManager.InventorySlots[operationalIndex].Image;
        }
        if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            button = inventorySlots[operationalIndex];
            img = button.transform.GetChild(0).GetComponent<RawImage>();
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
            img.texture = null;
        }
    }

    private void ItemsRemoval_GetIndex(int index)
    {
        operationalIndex = index;
    }
}
