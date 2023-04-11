using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected GameObject target;
    public GameObject player;

    public virtual void Start()
    {
        if(player != null)
        {
        target = FindObjectOfType<Movement>().gameObject;
        }
        return;

    }

}
