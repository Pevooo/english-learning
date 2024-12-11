using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;
using System.Collections.Generic;
public class QuestionMaker : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject questionprefab;
    public Sprite questionpic,choice1,choice2,choice3;
    public GameObject[] GetChildren(GameObject parent)
    {
        int childCount = parent.transform.childCount;
        GameObject[] children = new GameObject[childCount];

        for (int i = 0; i < childCount; i++)
        {
            children[i] = parent.transform.GetChild(i).gameObject;
        }

        return children;
    }


    void Start()
    {
        GameObject parentObject = this.gameObject; // Replace with your parent GameObject
        GameObject[] childObjects = GetChildren(parentObject);

        childObjects[0].GetComponent<SpriteRenderer>().sprite=choice1;
        childObjects[1].GetComponent<SpriteRenderer>().sprite=choice2;
        childObjects[2].GetComponent<SpriteRenderer>().sprite=choice3;
        childObjects[3].GetComponent<SpriteRenderer>().sprite=questionpic;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.name=="Spell Explosion(Clone)"){
            Destroy(gameObject);
        }
      

        
    }

  
   
}
