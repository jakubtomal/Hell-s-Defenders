using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float walkingSpeed = 0f;
    GameObject Currenttarget;



    private void Awake()
    {
        FindObjectOfType<LevelManager>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();

        if(levelManager != null)
        {
            levelManager.AttackerKilled();
        }
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * walkingSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!Currenttarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        Currenttarget = target;
    }

    public void StrikeCorrentTarget(int damage)
    {
        if (!Currenttarget) { return; }
        Health health = Currenttarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }

    }


    public void SetMovementSpeed(float speed)
    {
        walkingSpeed = speed;
    }

    
}
