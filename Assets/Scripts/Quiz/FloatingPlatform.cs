using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float Speed = 2.0f; // Maximum speed at the middle
    public float Range = 20f; // Total range for floating
    private Vector2 startPosition;
    private float time;

    void Start() {
        startPosition = transform.position; // Record the initial position
    }

    void Update() {
        // Use a sine wave to calculate the offset
        float offset = Mathf.Sin(time) * Range;

        // Update the position based on the sine wave
        transform.position = startPosition + Vector2.up * offset;

        // Increment time to create continuous motion
        time += Speed * Time.deltaTime;
    }
}
