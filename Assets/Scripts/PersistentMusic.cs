using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
    private static PersistentMusic instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
