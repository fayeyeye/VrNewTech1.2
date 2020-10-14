using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    public GameObject smallPlayer;
    public GameObject largePlayer;

    public bool playerSize; //false is small, big is true
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            SwitchSize();
        }
    }

    public void SwitchSize()
    {
        playerSize = !playerSize;

        smallPlayer.SetActive(!smallPlayer.activeSelf);
        largePlayer.SetActive(!smallPlayer.activeSelf);
    }
}
