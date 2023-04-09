using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTeleporter : MonoBehaviour
{
    public Vector3 teleportPosition = new Vector3(1, 2, 3); // The coordinates where you want to teleport the player to.
    public Tilemap leftLadderTilemap; // The Tilemap that represents the left ladder.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && leftLadderTilemap.HasTile(leftLadderTilemap.WorldToCell(transform.position))) // If the player character enters the left ladder zone...
        {
            transform.position = teleportPosition; // ...teleport the player to the desired position.
        }
    }
}