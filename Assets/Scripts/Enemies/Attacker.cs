using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float damage = 10.0f;
    [Range(0f, 5f)]float currentSpeed = 1f;
    GameObject currentTarget = null;
    Animator animator = null;
    float difficulty = 1.0f;

    private void Start()
    {
        difficulty = PlayerPrefsController.GetMasterDifficulty();
        animator = GetComponent<Animator>();
        Debug.Log(gameObject.name + " initial damage: " + damage);
        damage *= difficulty;
        Debug.Log(gameObject.name + " difficulty damage: " + damage);
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

    public float GetDamage()
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
