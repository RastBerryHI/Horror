using UnityEngine;
using UnityEngine.UI;

public class Collactable : MonoBehaviour, IInterractiveItem
{
    [SerializeField] private int nameId;
    [SerializeField] private Texture image;
    /// <summary>
    /// Hashed name string id
    /// </summary>
    /// <value></value>
    public int NameID => nameId;

    public Texture Image => image;

    private void Awake()
    {
        nameId = Animator.StringToHash(name);
    }

    public void OnIterraction(GameObject sender)
    {
        InventoryManager inventory = sender.GetComponent<InventoryManager>();

        if (inventory == null)  
        {
            return;
        }

        inventory.AddToInventory(this);
        Destroy(GetComponent<Collider>());
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
