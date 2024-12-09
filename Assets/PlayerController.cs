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
    Rigidbody2D rb;
    bool isOnGround;
    void Start()
    {

        // Setting current sprite
        string player = PlayerPrefs.GetString("Character");
        Debug.Log(player);
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
        if (movement < -0.2) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else if (movement > 0.2) {
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
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void SetCameraPosition() {
        Vector3 newPositon = mainCamera.transform.position;
        newPositon.x = Math.Max(transform.position.x + 5f, 0);
        mainCamera.transform.position = newPositon;
    }

    void OnCollisionStay2D(Collision2D collision) {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
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
        } else
        {
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
}