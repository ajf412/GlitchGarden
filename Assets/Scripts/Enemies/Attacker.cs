using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [Range(0f, 5f)]float currentSpeed = 1f;
    GameObject currentTarget = null;
    Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddAttacker();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().RemoveAttacker();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        if (!currentTarget)
        {
            animator.SetBool("isAttacking", false);
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
            // Debug.Log("removing " + damage + " damage from " + currentTarget.name);
        }
    }
}
