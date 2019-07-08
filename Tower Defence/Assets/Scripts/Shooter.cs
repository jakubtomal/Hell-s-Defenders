using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] projectile projectilePrefab;
    [SerializeField] GameObject gun;
    Animator animator;

    GameObject projectilesParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    AttackerSpawner myLaneSpawner;


    private void Start()
    {

        animator = GetComponent<Animator>();
        SetLaneSpowner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectilesParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
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
        projectile newprojectile = Instantiate(projectilePrefab, gun.transform.position, gun.transform.rotation);

        newprojectile.transform.parent = projectilesParent.transform;
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
