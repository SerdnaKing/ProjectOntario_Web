using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    public double height;
    public GameObject water;
    ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        smoke = GetComponent<ParticleSystem>();  
    }

    void Update()
    {
        if(water.transform.position.y >=  height-3)
        {
            //Debug.Log("particle should play now");
            smoke.Play();
        }
        else
        {
            smoke.Stop();
        }
    }
}
