using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile = null, releasePoint = null;
    AttackerSpawner myLaneSpawner = null;

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("I am in lane " + transform.position.y + " and I'm shooting " + myLaneSpawner.transform.childCount + " Zombies.");
            // TODO Change animation state to shooting
        }
        else
        {
            Debug.Log("I am in lane " + transform.position.y + " and my lane count is: " + myLaneSpawner.transform.childCount);
            // TODO Change animation state to idle
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
