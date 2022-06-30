using UnityEngine;

/// <summary>
/// Player movement handling
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravityForce;

    private CharacterController characterController;
    private Transform m_Transform;

    private Vector3 inputMap;
    [SerializeField] private Vector3 movementDirection;

    public float Speed 
    {
        get => speed;
        set
        {
            speed = value;

            if (speed <= 0)
            {
                speed = 0.5f;
            }
        }
    }

    public float GravityForce
    {
        get => gravityForce;
        set
        {
            gravityForce = value;
        }
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        m_Transform = transform;
    }

    private void Update()
    {
        inputMap.x = Input.GetAxis("Horizontal");
        inputMap.z = Input.GetAxis("Vertical");

        MoveToDirection(speed);
    }

    private void MoveToDirection(float speed)
    {
        if (characterController != null) 
        {
            movementDirection = m_Transform.right * inputMap.x + 
            m_Transform.forward * inputMap.z;
            
            ApplyGravity();
            characterController.Move(movementDirection * speed * Time.deltaTime);
        }
    }

    private void ApplyGravity()
    {
        movementDirection.y = gravityForce;
    }
}
