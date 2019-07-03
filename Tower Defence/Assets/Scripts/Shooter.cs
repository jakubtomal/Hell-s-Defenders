using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] projectile projectilePrefab;
    [SerializeField] GameObject gun;
    Animator animator;

    AttackerSpawner myLaneSpawner;


    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpowner();
    }

    private void Update()
    {
        if(IsAttackerInLine())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void Fire()
    {
        Instantiate(projectilePrefab, gun.transform.position, gun.transform.rotation);
    }

    private bool IsAttackerInLine()
    {
        if(myLaneSpawner.GetComponentsInChildren<Attacker>().Length <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }

    private void SetLaneSpowner()
    {

        var spawners = FindObjectsOfType<AttackerSpawner>();

        foreach( AttackerSpawner spawner in spawners)
        {
            bool isClouseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if(isClouseEnough)
            {
                myLaneSpawner = spawner;
            }
        }

    }

    
}
