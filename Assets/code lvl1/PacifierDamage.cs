using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacifierDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private HealthBar healthBar;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Pacifier collision with player");
            GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
            healthBar = healthBarObject.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.TakeDamage(damageAmount);
            }
        }
    }
}




