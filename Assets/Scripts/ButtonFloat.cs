using UnityEngine;

public class ButtonFloat : MonoBehaviour
{
    public float Speed = 2.0f; // Maximum speed at the middle
    public float Range = 20f; // Total range for floating
    private RectTransform rectTransform;
    private Vector2 startPosition;
    private float time;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition; // Record the initial position
    }

    void Update() {
        // Use a sine wave to calculate the offset
        float offset = Mathf.Sin(time) * Range;

        // Update the position based on the sine wave
        rectTransform.anchoredPosition = startPosition + Vector2.up * offset;

        // Increment time to create continuous motion
        time += Speed * Time.deltaTime;
    }
}
