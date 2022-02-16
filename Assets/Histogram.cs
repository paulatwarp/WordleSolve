using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Histogram
{
    public int [] letters;
    public static readonly int alphabet = 26;

    public static int IndexFromLetter(char letter)
    {
        int index = letter - 'a';
        Debug.Assert(index >= 0 && index < alphabet);
        return index;
    }

    public Histogram(string word)
    {
        letters = new int [alphabet];
        foreach (char letter in word)
        {
            letters[IndexFromLetter(letter)]++;
        }
    }

    public Histogram(Match match)
    {
        letters = new int [alphabet];
        for (int i = 0; i < match.clues.Length; ++i)
        {
            Match.Clue clue = match.clues[i];
            if (clue == Match.Clue.Correct || clue == Match.Clue.Used)
            {
                letters[IndexFromLetter(match.word[i])]++;
            }
        }
    }

    public Histogram(Histogram source)
    {
        letters = new int [alphabet];
        Copy(source);
    }

    public void Copy(Histogram source)
    {
        Array.Copy(source.letters, letters, alphabet);
    }

    public void Use(char letter)
    {
        letters[IndexFromLetter(letter)]--;
    }

    public bool Has(char letter)
    {
        return letters[IndexFromLetter(letter)] > 0;
    }
}
