using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSandbag : MonoBehaviour
{
    public GameObject sandbagPrefab;
    private readonly string sandbagTag = "playerSandbag";
    
    [SerializeField]
    private float placeDist = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 playerPos = transform.position;
            //Debug.DrawLine(playerPos, playerPos + (transform.forward * placeDist), Color.red, 100);
            if (Physics.Raycast(playerPos, transform.forward, out RaycastHit hit))
            {
                if (hit.distance < placeDist && (hit.collider.gameObject.tag == "terrain" || hit.collider.gameObject.name.ToLower().Contains("terrain")))
                {
                    Quaternion playerRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
                    Quaternion sandbagRot = Quaternion.Euler(0, playerRotation.eulerAngles.y, 0);
                    GameObject sandbag = Instantiate(sandbagPrefab, hit.point, sandbagRot);
                    sandbag.tag = sandbagTag;
                }
            }

        }
    }
}
