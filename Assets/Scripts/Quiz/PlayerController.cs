using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite HarrySprite;
    public Sprite RonSprite;
    public Sprite HermoineSprite;
    public float movementSpeed = 5.0f;
    public float jumpForce = 20.0f;
    public Camera mainCamera;
    public GameObject projectilePrefab;
    public float launchForce = 10f;    // The speed of the projectile
    public float cooldownTime = 0.5f;  // Cooldown duration in seconds
    private float lastLaunchTime = -Mathf.Infinity;
    private Rigidbody2D rb;
    private bool isOnGround;
    private bool isShaking = false;
    void Start()
    {

        // Setting current sprite
        string player = PlayerPrefs.GetString("Character");
        if (player == "HarryPotter") {
            GetComponent<SpriteRenderer>().sprite = HarrySprite;
        } else if (player == "RonWeasely") {
            GetComponent<SpriteRenderer>().sprite = RonSprite;
        } else {
            GetComponent<SpriteRenderer>().sprite = HermoineSprite;
        }


        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Left and Right movement
        float movement = Input.GetAxis("Horizontal");
        if (movement < -0.1) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (movement > 0.1) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.Translate(Vector2.right * movement * movementSpeed * Time.deltaTime);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            Jump();
        }

        // Moving camera with player
        SetCameraPosition();

        // Cast Spell if applicable
        if (Input.GetMouseButtonDown(0) && Time.time >= lastLaunchTime + cooldownTime)
        {
            LaunchProjectile();
        }

        // Check that the player has not fallen down
        if (transform.position.y < -10) {
            transform.position = new Vector3(-5, 1, 0);
        }
    }

    void Jump()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void SetCameraPosition() {
        Vector3 newPosition = mainCamera.transform.position;
        newPosition.x = Math.Max(transform.position.x + 5f, 0);
        newPosition.y = 5;
        mainCamera.transform.position = newPosition;
    }

    Vector3 GetCameraPosition() {
        Vector3 newPosition = mainCamera.transform.position;
        newPosition.x = Math.Max(transform.position.x + 5f, 0);
        newPosition.y = 5;
        return newPosition;
    }

    void OnCollisionStay2D(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.1f)
            {
                isOnGround = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        isOnGround = false;
    }

   void LaunchProjectile()
    {

        // Play Sound
        GetComponent<AudioSource>().Play();


        Vector3 screenMousePosition = Input.mousePosition;
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(screenMousePosition.x, screenMousePosition.y, Mathf.Abs(Camera.main.transform.position.z))
        );

        // Calculate direction
        Vector3 direction = (mousePosition - transform.position).normalized;
        if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        // Spawn the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Apply force to the projectile's Rigidbody2D
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * launchForce;

        // Update the last launch time
        lastLaunchTime = Time.time;
    }

    public void StartCameraShake() {
        if (!isShaking) {
            StartCoroutine(Shake(0.5f, 0.2f));
        }
    }
    private IEnumerator Shake(float duration, float magnitude)
    {
        isShaking = true;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float offsetX = UnityEngine.Random.Range(-1f, 1f) * magnitude * ((duration - elapsed) / duration);
            float offsetY = UnityEngine.Random.Range(-1f, 1f) * magnitude * ((duration - elapsed) / duration);

            mainCamera.transform.localPosition = GetCameraPosition() + new Vector3(offsetX, offsetY, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        SetCameraPosition();
        isShaking = false;
    }
}
