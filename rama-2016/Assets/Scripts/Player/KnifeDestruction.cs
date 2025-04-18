using UnityEngine;

public class KnifeDestruction : MonoBehaviour
{
    [SerializeField] float lifeSpanw = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeSpanw);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
