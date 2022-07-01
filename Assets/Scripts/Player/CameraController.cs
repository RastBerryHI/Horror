using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensetivity;
    [SerializeField, Range(0, 90f)] private float maxLookUpAngle;
    [SerializeField, Range(-90f, 0)] private float minLookUpAngle;

    private Camera cam;
    private Transform playerBody;
    private Transform m_Transform;

    private Vector3 lookDirection;
    private float xRotation;

    private void Awake()
    {
        playerBody = transform.parent;
        m_Transform = transform;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        lookDirection.x = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        lookDirection.z = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;

        xRotation -= lookDirection.z; 
        xRotation = Mathf.Clamp(xRotation, minLookUpAngle, maxLookUpAngle);

        m_Transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * lookDirection.x);
    }
}
