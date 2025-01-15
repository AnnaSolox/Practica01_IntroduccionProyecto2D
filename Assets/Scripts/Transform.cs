using Unity.VisualScripting;
using UnityEngine;

public class GloboHelio : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5.0f;
    private Vector2 position;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("El objeto no tiene un RigidBody2D.");
        } else
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveY, 0f);

        position = new Vector2(transform.position.x, transform.position.y);
        transform.position = new Vector3(position.x, position.y, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        
    }
}
