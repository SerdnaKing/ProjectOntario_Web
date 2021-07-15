using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodController : MonoBehaviour
{




    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.I))
            {
            this.transform.Translate(Vector3.up * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.K))
            {
            this.transform.Translate(Vector3.down * Time.deltaTime);
        }
        }
    }

