using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 6.0f;
    [SerializeField] private float moveDirection;
    [SerializeField] private bool facingRaght = true;

    Rigidbody rb;
    Animator animator;


    const float angleFlipCharacter = 180.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection * maxSpeed, rb.angularVelocity.y);

        CheckMoveDirectionOfCharacter();        
    }

    void Flip()
    {
        facingRaght = !facingRaght;
        transform.Rotate(Vector3.up, angleFlipCharacter, Space.World);
    }

    void CheckMoveDirectionOfCharacter()
    {
        if (moveDirection > 0.0f && !facingRaght)
        {
            Flip();
        }
        else if (moveDirection < 0.0f && facingRaght)
        {
            Flip();
        }
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }
}
