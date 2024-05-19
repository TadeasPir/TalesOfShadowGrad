using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    
    public Material destroyedMaterial;

    private void Start()
    {
        
        currentHealth = maxHealth;
        
    }
        
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
       

        if (currentHealth <= 5)
        {
            this.GetComponent<Renderer>().material = destroyedMaterial;
        }

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
         
        }

    }

}
