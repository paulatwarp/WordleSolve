using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Text text;
    public Image background;

    public void Set(char letter)
    {
        text.text = $"{char.ToUpper(letter)}";
        background.color = Color.white;
    }

    public void SetColour(Match.Clue clue)
    {
        switch (clue)
        {
            case Match.Clue.Correct:
                background.color = Color.green;
                break;
            case Match.Clue.Unused:
                background.color = Color.grey;
                break;
            case Match.Clue.Used:
                background.color = Color.yellow;
                break;
        }
    }
}
