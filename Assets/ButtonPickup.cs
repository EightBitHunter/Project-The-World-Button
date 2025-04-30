using UnityEngine;

public class ButtonPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAbilities abilities = collision.GetComponent<PlayerAbilities>();

            if (abilities != null)
            {
                abilities.hasButtonAbility = true;
                Debug.Log("Button Ability Acquired!");
                Destroy(gameObject); // Remove the pickup from the scene
            }
        }
    }
}

