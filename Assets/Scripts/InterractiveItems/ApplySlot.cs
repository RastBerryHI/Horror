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

            lastTween = needed.Mtransform.DOMove(milestones[i].position, applyInterval).onComplete;    
            
            if (i == 1)
            {
                lastTween += FinnishApply;
            }

            yield return waiter;
        }
    }

    private void FinnishApply()
    {
        Debug.LogWarning($"Done");
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
