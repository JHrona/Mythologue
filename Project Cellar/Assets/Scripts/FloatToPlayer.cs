using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatToPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float radius;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
    if (player != null)
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= radius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    }
}
