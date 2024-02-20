using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int remainingEnemies;
    public static bool isPlayerLocked = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        remainingEnemies = GameObject.FindGameObjectsWithTag("Pacifier").Length-1;
    }


    public void GumbaDefeated()
    {
        // Called when a Gumba is defeated
        remainingEnemies--;

        // Check if all enemies are defeated
        if (remainingEnemies == 0)
        {
            UnlockPlayer();
        }
    }

    private void UnlockPlayer()
    {
        Debug.Log("player unlocked");
        // Allow the player to leave the area
        isPlayerLocked = false;
    }

    public static bool IsPlayerLocked()
    {
        // Check if the player is currently locked in the area
        return isPlayerLocked;
    }
}


