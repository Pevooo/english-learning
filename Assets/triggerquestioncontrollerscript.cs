using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerQuestionController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuestionPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("test00");
        GameObject newObject = Instantiate(QuestionPrefab, Vector3.zero, Quaternion.identity);
        newObject.name = "QuestionController";

        
    }
}
