using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestionController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuestionPrefab;
    public string tag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
{
    if (other.name == "Character")
    {
        GameObject newObject = GameObject.FindGameObjectWithTag(tag);

        if (newObject != null)
        {
            newObject.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("No object found with tag: " + tag);
        }
    }
}
}
