using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public ScriptManager scriptManager;
    public Door door;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, scriptManager.instance.playerMovement.mainCameraTransform.forward, out hit, 2))
        {
            Debug.DrawRay(transform.position, scriptManager.instance.playerMovement.mainCameraTransform.forward);
            if (hit.collider.name.Contains("Door"))
            {
                door = hit.collider.GetComponent<Door>();
                door.doorTxt.SetActive(true);
            }
            else
            {
                if (door != null)
                {
                    Debug.Log("Null");
                    door.doorTxt.SetActive(false);
                }
            }
        }
    }
}
