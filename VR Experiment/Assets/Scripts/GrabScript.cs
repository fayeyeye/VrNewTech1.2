 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private Transform prevParent;
    private GameObject grabbedObject;

    private Vector3 currentObjectLoc;
    private Vector3 lastObjectLoc;

    private bool firstGrab;

    public bool LeftHand;
    public bool RightHand;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        releaseObject();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && ((LeftHand == true && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.75f) || (RightHand == true && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.75f)))
        {
            //grab object
            grabbedObject = other.gameObject;

            if (firstGrab == false)
            {
                if (grabbedObject.transform.parent != null)
                    prevParent = grabbedObject.transform.parent;

                firstGrab = true;
            }
            grabbedObject.transform.SetParent(this.transform);

            grabbedObject.transform.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void releaseObject()
    {
        if (grabbedObject != null)
        {

            if ((LeftHand == true && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.75f) || (RightHand == true && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.75f))
            {
                //release object

                grabbedObject.transform.SetParent(prevParent);

                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;

                if (LeftHand == true)
                    grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);

                if(RightHand == true)
                    grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

                firstGrab = false;
            }
        }
    }
}
