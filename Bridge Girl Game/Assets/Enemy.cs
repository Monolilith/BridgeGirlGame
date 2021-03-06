﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{ 
    //public float force = 100;
    public int health = 20;
    public Animator anim;
    //public Slider hp;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    //public Transform homePos;
    public Vector3 change;
    public float moveSpeed;
    public NavMeshAgent agent;

    private bool pause;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        
    }

// Update is called once per frame
void Update()
{
        if(!pause)
    CheckRad();

    Death();
    //hp.value = health;
    
}

private void Death()
{
    if (health <= 0)
    {
        Destroy(gameObject, 2f);
      
    }
}



    void CheckRad()
    {
        //Chase Radius
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {

            agent.SetDestination(target.position);

            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target.transform);
        }

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            StartCoroutine("PauseBoy");
        }
    }

    public IEnumerator PauseBoy()
    {
        Debug.Log("Enemy pausing!");
        pause = true;
        yield return new WaitForSeconds(2);
        pause = false;

        yield break;
    }

}



