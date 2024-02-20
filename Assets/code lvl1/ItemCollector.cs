using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private HealthBar healthBar;

    private void Start()
    {
        healthBar = GameObject.FindObjectOfType<HealthBar>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            healthBar.CollectFireWok();
        }
    }
}

