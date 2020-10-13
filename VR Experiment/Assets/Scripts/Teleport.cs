using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleport : MonoBehaviour
{
    private Transform player;
    public GameObject teleportVisualPrefab;
    private GameObject teleportVisual;
    // Start is called before the first frame update
    void Start()
    {
        teleportVisual = Instantiate(teleportVisualPrefab);
        player = this.transform.root;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        //maybe check if it is on the ground layer
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            //if(hit.distance < too small){ Dont();}

            teleportVisual.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.75f)
            {
                //teleport
                player.transform.position = new Vector3(hit.point.x, player.transform.position.y, hit.point.z);
            }
        }

        else
        {
            teleportVisual.transform.position = new Vector3(0, -1000, 0);
        }
        //shoot raycast at ground
        //Check if the distance is not too close to the player
        //If the distance is far enough, show teleport option
        //It the player presses the teleport button, move his position
        //Maybe add a way that it doesn't feel really weird (we don't want it to be instant or people will barf)
    }
}
