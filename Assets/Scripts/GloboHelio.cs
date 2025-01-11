using Unity.VisualScripting;
using UnityEngine;

public class GloboHelio : MonoBehaviour
{

    public float moveSpeed = 6f;
    public float ascendSpeed = .1f;
    public float maxAscendSpeed = 2f;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("El objeto no tiene un RigidBody2D.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        float currentVerticalSpeed = rb.linearVelocityY;

        if (currentVerticalSpeed < maxAscendSpeed)
        {
            rb.AddForce(Vector2.up*ascendSpeed);
        }
    }
}
