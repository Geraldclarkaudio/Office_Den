using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Door : MonoBehaviour
{
    [SerializeField]
    private bool canOpen;

    private StarterAssetsInputs _inputs;

    private Animator _anim;
    private UIManager _uiManager;
    [SerializeField]
    private GameObject instructionPanel;

    private void Start()
    {
        _inputs = GameObject.Find("PlayerCapsule").GetComponent<StarterAssetsInputs>();
        _anim = GetComponentInChildren<Animator>();
        _uiManager = GameObject.Find("UI").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canOpen = true;
            _uiManager.OpenDoorText();
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
        if (_inputs.interact == true)
        {
            if (canOpen == true)
            {
                Debug.Log("oPENED");
                _anim.SetTrigger("Open");
                canOpen = false;
            }
            else if (canOpen == false)
            {
                return;
            }
        }
    }       
}
