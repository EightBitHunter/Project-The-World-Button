using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishPoint : MonoBehaviour
{

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    IEnumerator WaitAndExecute()
        {
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.checkpoint);
            StartCoroutine(WaitAndExecute());
        }
    }

}
