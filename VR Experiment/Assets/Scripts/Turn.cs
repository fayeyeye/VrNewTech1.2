using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x > 0.5f)
        {
            player.rotation  = Quaternion.Euler(player.localRotation.x , player.localRotation.y + 45, player.localRotation.z);
        }

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x < -0.5f)
        {
            player.rotation = Quaternion.Euler(player.localRotation.x, player.localRotation.y - 45, player.localRotation.z);
        }
        //turn the controller stick to the right and turn right (same with left)
        //Snap turns are better for motion sickness
        //Don't forget to do it only once until the player releases the stick
        //otherwise they'll be turning at lightspeed
    }
}
