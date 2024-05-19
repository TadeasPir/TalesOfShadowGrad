using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    
   
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    private void Awake()
    {
       currentHealth = maxHealth;
    }
    public void TakeDamage(int damage) 
    {
    currentHealth -= damage;
        Debug.Log(transform.name + "took"+damage+"damage");
    

        if (currentHealth < 0) 
        {
           
            Die();
        }
    }

    public virtual void Die() 
    {
        //TODO create a proper game over
        Debug.Log(transform.name+"died");
    }


    void Update() {
        /*  test of damager
          if (Input.GetKeyDown(KeyCode.T)) 
         {
             TakeDamage(10); 
         }
          */

    }
}
