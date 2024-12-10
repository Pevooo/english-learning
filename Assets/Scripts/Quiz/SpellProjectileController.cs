using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectileController : MonoBehaviour
{
    public GameObject particlePrefab;
    private PlayerController controller;
    void Start()
    {
        controller = GameObject.Find("Character").GetComponent<PlayerController>();
        Destroy(gameObject, 5);
    }
    void OnCollisionEnter2D(Collision2D collision) {

        // Explosion Sound
        GetComponent<AudioSource>().Play();


        // Explosion Particles
        var particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        particles.GetComponent<ParticleSystem>().Play();

        // Camera Shake
        controller.StartCameraShake();
        
        
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(particles, 5);
        Destroy(gameObject, 5);
    }

    void OnCollisionStay2D(Collision2D collision) {
        OnCollisionEnter2D(collision);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Character")
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
