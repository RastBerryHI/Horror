using UnityEngine;

/// <summary>
/// Player movement handling
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravityForce;

    private CharacterController characterController;

    private Vector3 movementDirection;

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
    }

    private void Update()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.z = Input.GetAxis("Vertical");

        MoveToDirection(speed);
        ApplyGravity();
    }

    private void MoveToDirection(float speed)
    {
        if (characterController != null) 
        {
            characterController.Move(movementDirection * speed * Time.deltaTime);
        }
    }

    private void ApplyGravity()
    {
        movementDirection.y = gravityForce;
    }
}
