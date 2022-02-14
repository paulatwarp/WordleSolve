using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match
{
    public enum Clue
    {
        NotSet,
        Unused,
        Used,
        Correct
    }

    public Clue [] clues;
    public string word;
    int [] used = new int [256];

    public Match(string word)
    {
        this.word = word;
        clues = new Clue [word.Length];
    }

    public void Set(string start)
    {
        this.word = start;
        for (int i = 0; i < clues.Length; ++i)
        {
            clues[i] = Clue.NotSet;
        }
    }

    public void Score(string target)
    {
        for (int i = 0; i < used.Length; ++i)
        {
            used[i] = 0;
        }
        int size = word.Length;
        for (int i = 0; i < size; ++i)
        {
            used[target[i]]++;
        }

        for (int i = 0; i < size; ++i)
        {
            char letter = word[i];
            if (target[i] == letter)
            {
                clues[i] = Clue.Correct;
                used[letter]--;
            }
        }

        for (int i = 0; i < size; ++i)
        {
            if (clues[i] == Clue.NotSet)
            {
                char letter = word[i];
                if (used[letter] > 0)
                {
                    clues[i] = Clue.Used;
                    used[letter]--;
                }
                else
                {
                    clues[i] = Clue.Unused;
                }
            }
        }
    }

    public bool CanReject(string candidate)
    {
        bool reject = false;
        for (int i = 0; i < word.Length; ++i)
        {
            switch (clues[i])
            {
                case Clue.Correct:
                    if (word[i] != candidate[i])
                    {
                        reject = true;
                    }
                    break;
                case Clue.Used:
                    if (!candidate.Contains(word[i].ToString()))
                    {
                        reject = true;
                    }
                    break;
                case Clue.Unused:
                    if (candidate.Contains(word[i].ToString()))
                    {
                        reject = true;
                    }
                    break;
            }

            if (reject)
            {
                break;
            }
        }

        return reject;
    }
}
