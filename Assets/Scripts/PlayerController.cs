using UnityEngine;
using System.Collections;

/// <summary>
/// Player movement handling
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float gravityForce;

    private CharacterController characterController;
    private Transform m_Transform;
    public Camera camera;

    private Vector3 inputMap;
    [SerializeField] private Vector3 movementDirection;

    [Header("Crouching params")]
    private bool isCrouching = false;
    private float standingHeight = 2f;
    private float crouchingHeight = 0.5f;
    private Vector3 standingCenter = new Vector3(0, 0, 0);
    private Vector3 crouchingCenter = new Vector3(0,0.5f,0);
    private float timeToCrouch = 0.25f;
    private bool duringCrouch;

    public float CrouchSpeed
    {
        get => crouchSpeed;
        set
        {
            crouchSpeed = value;
            if (crouchSpeed <= 0)
            {
                crouchSpeed = 0.1f;
            }
        }
    }

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
        if (Input.GetKey(KeyCode.LeftControl)&&!duringCrouch&&characterController.isGrounded)
        {
            StartCoroutine(CrouchStand());
        }
        float currentSpeed = isCrouching ? crouchSpeed : speed;
        MoveToDirection(currentSpeed);
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

    private IEnumerator CrouchStand()
    {
        if (isCrouching && Physics.Raycast(camera.transform.position, Vector3.up, 0.5f))
            yield break;
        if (characterController != null)
        {
            duringCrouch = true;
            float targetHeight = isCrouching ? standingHeight : crouchingHeight;
            float currentHeight = characterController.height;
            Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
            Vector3 currentCenter = characterController.center;
            float elapsedTime = 0;
            while (elapsedTime < timeToCrouch)
            {
                characterController.center = Vector3.Lerp(currentCenter, targetCenter, elapsedTime / timeToCrouch);
                characterController.height = Mathf.Lerp(currentHeight, targetHeight, elapsedTime / timeToCrouch);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            characterController.height = targetHeight;
            characterController.center = targetCenter;
            isCrouching = !isCrouching;

            duringCrouch = false;
        }
    }

    private void ApplyGravity()
    {
        movementDirection.y = gravityForce;
    }
}
