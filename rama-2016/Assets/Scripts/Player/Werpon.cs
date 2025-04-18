using UnityEngine;

public class Werpon : MonoBehaviour
{
    [SerializeField] float knifeSpeed = 600.0f;
    const string nameKnifeSpawner = "KnifeSpawn";
    const string nameKnifeAnimation = "Attacking";
    [SerializeField] private Transform knifeSpawn;
    [SerializeField] Rigidbody knifePrefab;
    Rigidbody clone;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        knifeSpawn = GameObject.Find(nameKnifeSpawner).transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Attack();
        }
    }

    void Attack() 
    {
        animator.SetTrigger(nameKnifeAnimation);        
    }

    public void CallFireProjectile() 
    {
        clone = Instantiate(knifePrefab, knifeSpawn.position, knifeSpawn.rotation) as Rigidbody;
        clone.AddForce(knifeSpawn.transform.right * knifeSpeed);
    }
}
