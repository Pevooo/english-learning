using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] Timer timer1;
    // Start is called before the first frame update
    void Start()
    {
        timer1.SetDuration(120).Begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
