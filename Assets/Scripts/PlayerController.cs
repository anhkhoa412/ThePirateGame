using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    private bool isDead;

    [SerializeField] private AudioClip side, die;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!isDead)
        {
            // Kiểm tra người dùng bấm chuột trái vào màn hình và không bấm lên UI
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (transform.position.x >= 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                audioSource.PlayOneShot(side); // Phát âm thanh 1 lần
                transform.position = new Vector2(-transform.position.x, transform.position.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            isDead = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            audioSource.PlayOneShot(die);
            Debug.Log("End Game");
            GameManager.Instance.GameOver();
        }
    }
}
