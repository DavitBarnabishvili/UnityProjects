using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorChange : MonoBehaviour
{
    public Texture2D customCursor; // Assign your custom cursor texture in the Inspector

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        cursorSet(customCursor);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && !PauseMenuScript.GameIsPaused)
        {
            Debug.Log("Cursor Hidden");
            Cursor.visible = false;
        }
        else {
            Cursor.visible = true;
        }
    }


    void cursorSet(Texture2D tex)
    {
        CursorMode mode = CursorMode.ForceSoftware;
        float xspot = tex.width / 3;
        float yspot = tex.height / 3;
        Vector2 hotSpot = new Vector2(xspot, yspot);
        Cursor.SetCursor(tex, hotSpot, mode);
    }
}