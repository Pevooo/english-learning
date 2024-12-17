using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System;
public class QuestionMaker : MonoBehaviour
{    
    public GameObject rightAnswer;
    
    public void DestroyQuestion() {
        Destroy(gameObject);
    }
}
