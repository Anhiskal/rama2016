using UnityEngine;

public class TestJump : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 600.0f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {            
            rb.AddForce(new Vector2(0, jumpSpeed));
        }
    }
}
