using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float BulletSpeed;
    public float Direction;
    public float minAngle;
    public float maxAngle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = Random.Range(minAngle, maxAngle);
        rb.velocity = new Vector2(Direction, BulletSpeed);
    }
    private void Update()
    {
        rb.velocity = new Vector2(Direction, BulletSpeed);
        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))
        {
            Destroy(gameObject);
        }
    }
}
