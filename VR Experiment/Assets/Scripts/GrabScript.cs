 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private Transform prevParent;
    private GameObject grabbedObject;

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
        if(grabbedObject != null && (LeftHand == true && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.75f) || (RightHand == true && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.75f))
        {
            //release object
            if (prevParent != null)
                grabbedObject.transform.SetParent(prevParent);

            else
                grabbedObject.transform.SetParent(null);

            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            firstGrab = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && (LeftHand == true && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) >= 0.75f) || (RightHand == true && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) >= 0.75f))
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
}
