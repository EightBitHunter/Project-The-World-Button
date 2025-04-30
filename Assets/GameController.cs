using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D playerRb;

    AudioManager audioManager;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
            audioManager.PlaySFX(audioManager.death);
        }
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.linearVelocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        transform.localScale = new Vector3(1, 1, 1);
        playerRb.simulated = true;
    }
}
