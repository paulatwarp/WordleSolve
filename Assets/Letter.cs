using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Text text;

    public void SetLetter(char letter)
    {
        text.text = letter.ToString().ToUpper();
    }
}
