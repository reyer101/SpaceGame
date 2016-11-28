using UnityEngine;
using System.Collections;

public class StarBoundary
{
    public float xMin, xMax, zMin, zMax;
}

public class StarMover : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;    
    public StarBoundary boundary;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * speed;                
    }         
    void FixedUpdate()
    {
        if (rb.position.x < 6 && rb.velocity == transform.right * speed)
        {
            rb.velocity = transform.right * speed;
        }
        if (rb.position.x >= 6)
        {
            rb.velocity = transform.right * -speed;
            return;
        }
        if (rb.position.x <= -6 && rb.velocity == transform.right * -speed)
        {
            rb.velocity = transform.right * speed;
        }
    }
}
