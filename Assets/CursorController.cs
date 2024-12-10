using UnityEngine;

public class CursorController : MonoBehaviour
{
    public static CursorController Instance;

    public Texture2D customCursor;
    public Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Cursor.SetCursor(customCursor, hotSpot, CursorMode.Auto);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
