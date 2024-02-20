using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenuScript : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level 1 (journey)");
    }

    public void Level2() {
        SceneManager.LoadScene("Level 2 (signagi)");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3 (didgori)");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4 (kazbegi)");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level 5 (baxmaro)");
    }
}
