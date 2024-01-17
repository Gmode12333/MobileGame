using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject BubblePrefab;
    public GameObject BuffPrefab;
    public Transform SpawnTransform;

    public float BubbleSpeed;
    public float SpawnRate;
    public float BuffDropRate;
    private void Start()
    {
        StartCoroutine(StartSpawn());
        StartCoroutine(BuffDrop());
        SpawnRate = GameManager.Instance.DropRate;
    }
    public void SpawnBubble()
    {
        var prefab = Instantiate(BubblePrefab, transform.position, Quaternion.identity);
        prefab.transform.SetParent(SpawnTransform);
        prefab.transform.localScale = new Vector3(1f, 1f, 1f);
        BubblePrefab.GetComponent<Rigidbody2D>().gravityScale = BubbleSpeed;
    }
    public void SpawnBuff()
    {
        var buff = Instantiate(BuffPrefab, transform.position, Quaternion.identity);
        buff.transform.SetParent(SpawnTransform);
        buff.transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void GetRandomPostion()
    {
        float x = Random.Range(-2.5f, 2.5f);
        this.gameObject.transform.position = new Vector2(x, 6f);
    }
    IEnumerator StartSpawn()
    {
        while (!GameManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(SpawnRate);
            GetRandomPostion();
            SpawnBubble();
            SpawnRate = GameManager.Instance.DropRate;
        }
    }
    IEnumerator BuffDrop()
    {
        while (!GameManager.Instance.isGameOver)
        {
            yield return new WaitForSeconds(BuffDropRate);
            GetRandomPostion();
            SpawnBuff();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
