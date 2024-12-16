using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;
public class QuestionMaker : MonoBehaviour
{
    public Sprite questionSprite;
    public Sprite choice1;
    public Sprite choice2;
    public Sprite choice3;
    public GameObject rightAnswer;
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
        GameObject[] childObjects = GetChildren(gameObject);

        // childObjects[0].GetComponent<SpriteRenderer>().sprite = choice1;
        // childObjects[1].GetComponent<SpriteRenderer>().sprite = choice2;
        // childObjects[2].GetComponent<SpriteRenderer>().sprite = choice3;
        // childObjects[3].GetComponent<SpriteRenderer>().sprite = questionSprite;
    }

    public void DestroyQuestion() {
        Destroy(gameObject);
    }
}
