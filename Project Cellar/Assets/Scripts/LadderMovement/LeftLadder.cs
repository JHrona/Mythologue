using UnityEngine;

public class LadderMovement : MonoBehaviour
{
 public Vector2 teleportPosition = new Vector2 (1, 2); // The coordinates where you want to teleport the character to.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // If the player character enters the trigger zone...
        {
            collision.transform.position = teleportPosition; // ...teleport the player to the desired position.
        }
    }
}
