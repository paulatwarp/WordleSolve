using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public Letter prefab;
    public int size = 5;
    List<Letter> letters = new List<Letter>();
    string word;

    void Start()
    {
        for (int i = 0; i < size; ++i)
        {
            letters.Add(Instantiate(prefab, transform));
        }
    }

    public void Set(string word)
    {
        this.word = word;
        for (int i = 0; i < size; ++i)
        {
            letters[i].Set(word[i]);
        }
    }

    public void Set(Match match)
    {
        Set(match.word);
        for (int i = 0; i < size; ++i)
        {
            letters[i].SetColour(match.clues[i]);
        }
    }
}
