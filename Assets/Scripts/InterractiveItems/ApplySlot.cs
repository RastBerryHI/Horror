using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ApplySlot : MonoBehaviour, IInterractiveItem
{
    [Tooltip("Input IInterractiveItem prefab name to apply")]
    public string itemName;

    [SerializeField] private int itemId;
    [SerializeField] private Transform firstMilestone;
    
    private Appliable needed;
    private bool isSucceed;

    public UnityEvent onApplyFinnish;

    private void Start()
    {
        itemId = Animator.StringToHash(itemName);
        itemName = null;
    }

    public void OnIterraction(GameObject sender)
    {
        if (isSucceed)
        {
            return;
        }

        InventoryManager inventory = sender.GetComponent<InventoryManager>();
        needed = inventory?.GetFromInventory(itemId)?.GetComponent<Appliable>();

        if (needed != null)
        {  
            needed.Mtransform.rotation = firstMilestone.rotation;
            needed.Mtransform.DOMove(firstMilestone.position, 1).onComplete += OnMilestoneReached;
            isSucceed = true;
        }
    }

    private void OnMilestoneReached()
    {
        needed.Mtransform.DOKill(true);
        needed.Mtransform.DOMove(transform.position, 1).onComplete += OnSuccess;
    }

    private void OnSuccess()
    {
        onApplyFinnish.Invoke();
    }
}
