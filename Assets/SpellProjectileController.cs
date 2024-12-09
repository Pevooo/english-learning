using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjectileController : MonoBehaviour
{
    public GameObject particlePrefab;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject, 5);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        var particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);
        particles.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Character")
        {
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }


}
