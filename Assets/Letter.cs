using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Image background;
    public Text text;

    public void SetLetter(char letter)
    {
        text.text = letter.ToString().ToUpper();
    }

    internal void SetColour(Color green)
    {
        background.color = green;
    }
}
