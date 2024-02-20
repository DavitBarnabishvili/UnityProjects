using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int maxHearts = 5;
    public int currentHearts;
    private int atriaCounter;  // Counter for fireworks collected

    public Text fireWokText;

    public PlayerMovement playerMovement;  // Reference to the PlayerMovement script

    void Start()
    {
        currentHearts = maxHearts;
        atriaCounter = 0;

        // Make sure hearts array is initialized correctly
        if (hearts == null || hearts.Length != maxHearts)
        {
            Debug.LogError("Please assign the full heart images to the HealthBar script in the Inspector.");
            return;
        }

        UpdateHearts();
        fireWokText.text = $"FIREWOKS: {atriaCounter}";
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            int displayIndex = hearts.Length - 1 - i;  // Calculate the display index in reverse order
            if (i < currentHearts)
            {
                hearts[displayIndex].sprite = fullHeart;
            }
            else
            {
                hearts[displayIndex].sprite = emptyHeart;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        Debug.Log($"Player took {amount} damage");
        for (int i = 0; i < amount; i++)
        {
            if (currentHearts > 0)
            {
                currentHearts--;
                Debug.Log($"hearts: {currentHearts}");
                UpdateHearts();
            }
            else
            {
                return;
            }
        }
    }

    public void IncreaseHealth(int amount)
    {
        currentHearts = Mathf.Min(currentHearts + amount, maxHearts);
        UpdateHearts();
    }

    public void CollectFireWok()
    {
        atriaCounter++;

        if (atriaCounter >= 5)
        {
            atriaCounter = 0;
            IncreaseHealth(1);
        }

        fireWokText.text = $"FIREWOKS: {atriaCounter}";
    }
}



