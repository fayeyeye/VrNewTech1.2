using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmenu : MonoBehaviour
{
    public GameObject MenuElement;
    public GameObject tutorialElement;

    public GameObject StartButton;
    public GameObject QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        if (MenuElement)
            MenuElement.SetActive(true);
        if (tutorialElement)
            tutorialElement.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == StartButton && OVRInput.Get(OVRInput.Button.Two))
        {
            //start the game
            MenuElement.SetActive(false);
            tutorialElement.SetActive(true);
        }

        if(other.gameObject == QuitButton) { }
    }

}
