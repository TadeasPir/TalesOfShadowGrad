using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
   CharacterStats stats;
    public float attackSpeed = 1.0f;
    public float attackCooldown = 0.0f;

    void Start()
    {
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats) 
    {


        if ( attackCooldown <=0.0f)
        {
            targetStats.TakeDamage(stats.damage.GetValue());
            attackCooldown = 1.0f / attackSpeed;    
        }
    }
}
