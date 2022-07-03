using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ApplySlot : MonoBehaviour, IInterractiveItem
{
    [Tooltip("Input IInterractiveItem prefab name to apply")]
    public string itemName;

    [SerializeField] private int itemId;
    [SerializeField] private float applyInterval;
    private Transform firstMilestone;
    private Transform[] milestones;

    private Appliable needed;
    private WaitForSeconds waiter;
    private TweenCallback lastTween;
    private bool isSucceed;

    public UnityEvent onApplyFinnish;

    private void Awake()
    {
        milestones = GetComponentsInChildren<Transform>();
        waiter = new WaitForSeconds(applyInterval+0.5f);
    }

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
            needed.Mtransform.parent = transform;
            StartCoroutine(IterateThroughMilestones());

            isSucceed = true;
        }
    }

    private IEnumerator<WaitForSeconds> IterateThroughMilestones()
    {
        // Iterating till 1st element, ingoring parent one
        for (int i = milestones.Length-1; i > 0; i--)
        {
            if (i == milestones.Length-1)
            {
                needed.Mtransform.rotation = milestones[i].rotation;
            }

            if (i == 1)
            {
                needed.Mtransform.DOMove(milestones[i].position, applyInterval).onComplete += FinnishApply;
                break;
            }

            needed.Mtransform.DOMove(milestones[i].position, applyInterval);    
            
            yield return waiter;
        }
    }

    private void FinnishApply()
    {
        onApplyFinnish.Invoke();
        lastTween -= FinnishApply;
    }

    private void OnDestroy()
    {
        if (lastTween != null)
        {
            lastTween -= FinnishApply;
        }
    }

    private void OnDisable()
    {
        if (lastTween != null)
        {
            lastTween -= FinnishApply;
        }
    }
}
