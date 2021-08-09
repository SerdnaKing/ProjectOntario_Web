using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskDisable : MonoBehaviour
{

    public GameObject water;

    // Update is called once per frame
    void Update()
    {
        if(water.transform.position.y >= this.gameObject.transform.position.y + 0.6)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
