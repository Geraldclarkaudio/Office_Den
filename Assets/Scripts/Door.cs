using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool canOpen = true;

    private StarterAssetsInputs _inputs;

    [SerializeField]
    private Animator _anim;
    private UIManager1 _uiManager;
    [SerializeField]
    private GameObject instructionPanel;

    private void Start()
    {
        _inputs = GameObject.Find("Player").GetComponent<StarterAssetsInputs>();
       
        _uiManager = GameObject.Find("UI").GetComponent<UIManager1>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(canOpen == true)
            {
                _uiManager.OpenDoorText();
            }
            else if(canOpen == false)
            {
                _uiManager.CloseDoorText();
            }
            
            instructionPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canOpen = false;
            instructionPanel.SetActive(false);
        }
    }

    public void Update()
    {
        if(canOpen == true)
        {
            if(_inputs.interact == true)
            {
                Debug.Log("oPENED");
                _anim.SetTrigger("Open");
                _inputs.interact = false;
                canOpen = false;
            }
        }

        if(canOpen == false)
        {
            if(_inputs.interact == true)
            {
                _anim.SetTrigger("Close");
                _inputs.interact = false;
                canOpen = true;
            }
        }
    }       
}
