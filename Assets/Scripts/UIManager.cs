using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    public void OpenDoorText()
    {
        text.text = "Press E To Open The Door";
    }
    public void CloseDoorText()
    {
        text.text = "Press E To Close The Door";
    }

    public void Speak()
    {
        text.text = "Press E To Speak";
    }

}
