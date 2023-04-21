using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 10;
    public LayerMask attackLayer;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
                if (animator == null)
        {
            Debug.LogError("Animator component not found on player character.");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, attackLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().DealDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}