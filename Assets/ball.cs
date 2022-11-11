using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public float maxRotation;
    public float minRotation;
    public float maxSpeed;

    public Vector3 startPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Initialize()
    {
        transform.localPosition = startPosition;
        transform.rotation = Quaternion.Euler(0, Random.Range(minRotation, maxRotation), 0);
        rb.velocity = transform.forward * speed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity *= (rb.velocity.sqrMagnitude < maxSpeed * maxSpeed) ? 1.05f : 1f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<goal>(out goal goal))
        {
            goal.OnBallEnter();
        }
    }
}
