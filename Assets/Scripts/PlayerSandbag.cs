using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSandbag : MonoBehaviour
{
    public GameObject sandbagPrefab;
    public GameObject maskingPrefab;
    public CameraSwitch cameraController;
    private readonly string playerSandbagTag = "playerSandbag";
    private readonly string defaultSandbagTag = "defaultSandbag";
    private readonly string terrainTag = "terrain";

    [SerializeField]
    private float placeDist = 6;

    /// <summary>
    /// Controls placing/removing sandbags.
    /// 
    /// Right click terrain to place sand bag.
    /// Right click + shift to remove sand bag.
    /// 
    /// Sandbags not placed by player will be hidden instead so that show/hiding pondside/lakeside sandbags re-enables those sandbags
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Camera camera = cameraController.GetActiveCamera();

            // Removes sandbag
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                Vector3 playerPos = camera.transform.position;
                Debug.DrawLine(playerPos, playerPos + (transform.forward * placeDist), Color.red, 100);
                if (Physics.Raycast(playerPos, camera.transform.forward, out RaycastHit hit))
                {
                    if (hit.distance < placeDist)
                    {
                        GameObject hitObject = hit.collider.gameObject;
                        if (hitObject.tag == playerSandbagTag)
                        {
                            Destroy(hitObject);
                        }
                        else if(hitObject.tag == defaultSandbagTag)
                        {
                            hitObject.SetActive(false);
                        }
                    }
                }
            }

            // Places Sandbags and Mask
            else
            {
                Vector3 playerPos = camera.transform.position;
                Debug.DrawLine(playerPos, playerPos + (camera.transform.forward * placeDist), Color.red, 100);
                if (Physics.Raycast(playerPos, camera.transform.forward, out RaycastHit hit))
                {
                    if (hit.distance < placeDist && (hit.collider.gameObject.tag == terrainTag || hit.collider.gameObject.name.ToLower().Contains("terrain")))
                    {
                        Quaternion playerRotation = camera.transform.rotation * Quaternion.Euler(0, 90, 0);
                        Quaternion sandbagRot = Quaternion.Euler(0, playerRotation.eulerAngles.y, 0);
                        GameObject sandbag = Instantiate(sandbagPrefab, hit.point, sandbagRot);
                        sandbag.tag = playerSandbagTag;

                       
                        GameObject mask = Instantiate(maskingPrefab, new Vector3(hit.point.x - 1, hit.point.y, hit.point.z), sandbagRot);
                        
                    }
                }
            }
        }
    }
}
