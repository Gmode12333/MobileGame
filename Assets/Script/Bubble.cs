using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public int BubbleHealth;
    public Sprite[] BubbleSprite;
    public TextMeshProUGUI HealthText;

    public static int BubbleCount;

    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        image.sprite = BubbleSprite[Random.Range(0, BubbleSprite.Length)];
        BubbleHealth = GameManager.Instance.CurrentBubbleHealth;
        HealthText.text = BubbleHealth.ToString();
    }
    private void OnEnable()
    {
        BubbleCount++;
    }
    private void Update()
    {
        if(BubbleCount == 0)
        {
            Destroy(gameObject);
        }
        if(this.gameObject.transform.position.y < -10f)
        {
            BubbleCount--;
            Destroy(gameObject);
        }
        if(BubbleHealth <= 0)
        {
            SoundManager.Instance.PlaySound("Pop");
            BubbleCount--;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.Instance.AddScore();
            SoundManager.Instance.PlaySound("Hit");
            BubbleHealth--;
            HealthText.text = BubbleHealth.ToString();
        }
        if(collision.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            GameManager.Instance.GameOver();
        }
    }
}
