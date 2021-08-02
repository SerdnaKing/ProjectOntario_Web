using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamicController : MonoBehaviour
{

    public GameObject prefab;
    public GameObject mask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject lake = prefab.GetComponentInChildren<GameObject>();

        if (lake.transform.position.y >= this.transform.position.y + 0.85)
        {
            mask.SetActive(false);
        }
        else
        {
            mask.SetActive(true);
        }
    }
}
