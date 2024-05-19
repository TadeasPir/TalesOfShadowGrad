using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class enemyAiPatrol : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, PlayerLayer;
    BoxCollider boxCollider;
    PlayerManager playermanager;
    CharacterStats stats;
    

    Vector3 destPoint;
    bool walkpointSet;
        [SerializeField] float range;

    [SerializeField] float sightRange, attackRange;
    bool playerInSight,playerInAttackRange;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        boxCollider = GetComponent<BoxCollider>();
        playermanager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position,sightRange,PlayerLayer); 
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, PlayerLayer);
       
       
        

        if (!playerInSight && !playerInAttackRange) { Patrol(); } 
        if (playerInSight && !playerInAttackRange) { Chase(); } 
        if (playerInSight && playerInAttackRange) { Attack(); } 
    }
    void Attack()
    {
        
    }


    void Chase() 
    {
        agent.SetDestination(player.transform.position);
    }

    void Patrol() 
    {
        if (!walkpointSet) { SearchForDest(); } ;
        if (walkpointSet) { agent.SetDestination(destPoint); }

        if (Vector3.Distance(transform.position, destPoint) < 10) { walkpointSet = false; }

       

    }
    void SearchForDest() 
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x+x,transform.position.y,transform.position.z+z);
        if (Physics.Raycast(destPoint, Vector3.down,groundLayer)) 
        {
        walkpointSet = true;
        }

    }
    void EnableAttack() { boxCollider.enabled = true; }
    void DIsableAttack() { boxCollider.enabled = false; }

    private void OnTriggerEntrer(Collider other) 
    {
        CharacterCombat characterCombat = playermanager.player.GetComponent<CharacterCombat>();
        if (characterCombat != null) {
            
            characterCombat.Attack(stats); 
        }
    }
}
