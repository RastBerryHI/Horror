using UnityEngine;

public class Interractor : MonoBehaviour
{
    [SerializeField] private LayerMask interractionMask;
    [SerializeField] private float interractionRange;

    private Ray ray;
    private RaycastHit hit;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, interractionMask))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
