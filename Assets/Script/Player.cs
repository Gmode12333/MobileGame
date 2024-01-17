using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    [Header("Player")]
    public float Movespeed;
    public int GunLevel;
    [Header("Bullet")]
    public Transform BulletTransfrom;
    public float BulletSpeed;
    public float FireRate;

    public bool isDead;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GunLevel = GameManager.Instance.GunLevel;
        FireRate = GameManager.Instance.FireRate;
        StartCoroutine(Fire());
    }
    public void MoveLeft()
    {
        rb.AddForce(Vector2.left * Movespeed);
    }
    public void MoveRight()
    {
        rb.AddForce(Vector2.right * Movespeed);
    }
    private void Update()
    {
        FireRate = GameManager.Instance.FireRate;
        GunLevel = GameManager.Instance.GunLevel;
    }
    IEnumerator Fire()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(FireRate);
            for (int i = 0; i < GunLevel; i++)
            {
                var bullet = Instantiate(BulletPrefab, BulletTransfrom.position, Quaternion.identity);
                bullet.transform.SetParent(BulletTransfrom);
                bullet.transform.localScale = new Vector3(1f, 1f, 1f);
                bullet.GetComponent<Bullet>().minAngle = 0f - i;
                bullet.GetComponent<Bullet>().maxAngle = 0f + i;
            }
            SoundManager.Instance.PlaySound("Shoot");
            if (GameManager.Instance.isGameOver)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
