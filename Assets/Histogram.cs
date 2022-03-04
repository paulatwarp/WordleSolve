using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histogram
{
    public int [] letters;

    int LetterToIndex(char letter)
    {
        return letter - 'a';
    }

    public Histogram(string word)
    {
        letters = new int [26];
        foreach (var letter in word)
        {
            letters[LetterToIndex(letter)]++;
        }
    }

    internal void RemoveLetter(char letter)
    {
        letters[LetterToIndex(letter)]--;
    }

    internal bool HasLetter(char letter)
    {
        return letters[LetterToIndex(letter)] > 0;
    }
}
