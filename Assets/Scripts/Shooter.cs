using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null, releasePoint = null;
    AttackerSpawner myLaneSpawner;
    Animator animator = null;

    private void Start()
    {
        SetLaneSpawner();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("I am in lane " + transform.position.y + " and my spawner has " + myLaneSpawner.transform.childCount + " Attackers.");
            
            // Set ATTACK animation
            animator.SetBool("isAttacking", true);
        }
        else
        {
            Debug.Log("I am in lane " + transform.position.y + " and my lane is empty.");
            
            // Set IDLE animation
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y) - transform.position.y <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0){ return false; }
        else { return true; }
    }

    public void Attack(float damage)
    {
        if (projectile && releasePoint)
        {
            Instantiate(projectile, releasePoint.transform.position, Quaternion.identity);
        }
    }
}
