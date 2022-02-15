using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    public Letter prefab;
    public int size = 5;
    List<Letter> letters;

    private void Start()
    {
        letters = new List<Letter>();
        for (int i = 0; i < size; ++i)
        {
            letters.Add(Instantiate(prefab, transform));
        }
    }

    public void SetWord(string word)
    {
        Debug.Log(word.Length);
        for (int i = 0; i < word.Length; ++i)
        {
            letters[i].SetLetter(word[i]);
        }
    }
}
