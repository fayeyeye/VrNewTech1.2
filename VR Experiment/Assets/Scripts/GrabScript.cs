 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private Transform prevParent;
    private GameObject grabbedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbedObject != null && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) < 0.75f)
        {
            //release object
            if (prevParent != null)
                grabbedObject.transform.SetParent(prevParent);

            else
                grabbedObject.transform.parent = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.75f)
        {
            //grab object
            grabbedObject = other.gameObject;

            if (grabbedObject.transform.parent != null)
                prevParent = grabbedObject.transform.parent;

            grabbedObject.transform.SetParent(this.transform);
        }
    }
}
