using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 6.0f;
    private const string nameAnimationMove = "Speed";
    [SerializeField] private float moveDirection;
    [SerializeField] private bool facingRight = true;

    [Space(10)]
    private const string nameAnimationJump = "IsJumping";
    [SerializeField] private float jumpSpeed = 600.0f;
    [SerializeField] private bool grounded = false;
    [SerializeField] private Transform groundCheck;
    private const string nameObjectForCheckGround = "GroundCheck";
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    Rigidbody rb;
    Animator animator;


    const float angleFlipCharacter = 180.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Awake() 
    {
        groundCheck = GameObject.Find(nameObjectForCheckGround).transform;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame    
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (grounded && Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger(nameAnimationJump);
            GetComponent<Rigidbody>().AddForce(new Vector2(0, jumpSpeed));
        }
    }
    

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        rb.linearVelocity = new Vector2(moveDirection * maxSpeed, rb.linearVelocity.y);     

        CheckMoveDirectionOfCharacter();
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, angleFlipCharacter, Space.World);
    }

    void CheckMoveDirectionOfCharacter()
    {
        if (moveDirection > 0.0f && !facingRight)
        {
            Flip();
        }
        else if (moveDirection < 0.0f && facingRight)
        {
            Flip();
        }
        animator.SetFloat(nameAnimationMove, Mathf.Abs(moveDirection));
    }
}
