using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    private Transform prevParent;
    private GameObject grabbedObject;
    private bool grabbed = false;

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
            grabbedObject.transform.SetParent(prevParent);
            grabbed = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.75f && !grabbed)
        {
            //grab object
            grabbedObject = other.gameObject;
            prevParent = grabbedObject.transform.parent;
            grabbedObject.transform.SetParent(this.transform);
            grabbed = true;
        }
    }
}
