using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    public Letter prefab;
    public int size = 5;
    List<Letter> letters;

    private void Awake()
    {
        letters = new List<Letter>();
        Debug.Log($"letters = {letters}");
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
            Debug.Log($"i = {i}");
            Debug.Log($"word[i] = {word[i]}");
            Debug.Log($"letters[i] = {letters[i]}");
            letters[i].SetLetter(word[i]);
        }
    }

    internal void SetMatchedLetter(int i)
    {
        letters[i].SetColour(Color.green);
    }
}
