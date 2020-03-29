using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{ 
    public float force = 100;
    public int health = 20;
    public Animator anim;
    public Slider hp;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePos;
    public Vector3 change;
    public float moveSpeed;
    public NavMeshAgent agent;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        
    }

// Update is called once per frame
void Update()
{
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

            //transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            transform.LookAt(target.transform);
        }

      
    }

  
}



