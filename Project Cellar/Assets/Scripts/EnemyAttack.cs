using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    protected GameObject target;

    public virtual void Start()
    {
        target = FindObjectOfType<Movement>().gameObject;
    }

}
