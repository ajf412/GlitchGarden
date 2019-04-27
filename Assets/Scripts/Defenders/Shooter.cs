using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null, releasePoint = null;
    AttackerSpawner myLaneSpawner;
    Animator animator = null;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = gameObject.GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("Lane: " + transform.position.y + " Spawner: " + myLaneSpawner.name + " Child Count: " + myLaneSpawner.transform.childCount);
            
            // Set ATTACK animation
            animator.SetBool("isAttacking", true);
        }
        else
        {
            // Debug.Log("I am in lane " + transform.position.y + " and my lane is empty.");
            Debug.Log(name + "\'s spawner: " + myLaneSpawner.name, myLaneSpawner.gameObject);

            // Set IDLE animation
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - gameObject.transform.position.y) <= Mathf.Epsilon);
            // bool IsCloseEnough = (spawner.transform.position.y == gameObject.transform.position.y);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
                // return;
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
            GameObject newProjectile = Instantiate(projectile, releasePoint.transform.position, Quaternion.identity) as GameObject;
            newProjectile.transform.parent = projectileParent.transform;
        }
    }
}
