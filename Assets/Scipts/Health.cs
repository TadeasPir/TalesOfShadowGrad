using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public UnityEngine.UI.Slider healthSlider;
    // Start is called before the first frame update

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        healthSlider.value = health;
        if (health <= 0)
        {
            gameObject.transform.position = Vector3.zero;

            health = 100;
            healthSlider.value = health;
        }
    }
    public void Update()
    {
        Debug.Log(health);
    }
}
