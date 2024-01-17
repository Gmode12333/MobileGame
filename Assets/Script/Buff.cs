using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public float amount;
    public static int count;
    private void OnEnable()
    {
        count++;
    }
    private void Update()
    {
        if (GameManager.Instance.isGameOver || this.transform.position.y > 10f || count == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.FireRate -= amount;
            SoundManager.Instance.PlaySound("Upgrade");
            Destroy(gameObject);
        }
    }
}
