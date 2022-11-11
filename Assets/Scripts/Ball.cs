using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 30;
    public float maxSpeed = 50;
    public float aceleration = 1.05f;
    public float maxAngle, minAngle;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Initialize()
    {
        transform.localPosition = Vector3.zero;
        rb.velocity = Vector3.zero;
        float angle = Random.Range(minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.sqrMagnitude < maxSpeed*maxSpeed)
        {
            rb.velocity *= aceleration;
        }
    }
}