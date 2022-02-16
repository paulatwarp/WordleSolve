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
    Histogram histogram;

    public Match(string word)
    {
        this.word = word;
        clues = new Clue [word.Length];
        histogram = new Histogram(word);
    }

    void ClearClues()
    {
        for (int i = 0; i < clues.Length; ++i)
        {
            clues[i] = Clue.NotSet;
        }
    }

    public void Set(string start)
    {
        this.word = start;
        ClearClues();
        histogram = new Histogram(start);
    }

    public void Score(string target)
    {
        ClearClues();
        Histogram used = new Histogram(target);

        int size = word.Length;
        for (int i = 0; i < size; ++i)
        {
            char letter = word[i];
            if (target[i] == letter)
            {
                clues[i] = Clue.Correct;
                used.Use(letter);
            }
        }

        for (int i = 0; i < size; ++i)
        {
            if (clues[i] == Clue.NotSet)
            {
                char letter = word[i];
                if (used.Has(letter))
                {
                    clues[i] = Clue.Used;
                    used.Use(letter);
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
        Histogram used = new Histogram(candidate);
        bool reject = false;

        for (int i = 0; i < word.Length && !reject; ++i)
        {
            switch (clues[i])
            {
                case Clue.Correct:
                    if (word[i] == candidate[i])
                    {
                        used.Use(word[i]);
                    }
                    else
                    {
                        reject = true;
                    }
                    break;
            }
        }

        for (int i = 0; i < word.Length && !reject; ++i)
        {
            switch (clues[i])
            {
                case Clue.Used:
                    if (word[i] != candidate[i] && used.Has(word[i]))
                    {
                        used.Use(word[i]);
                    }
                    else
                    {
                        reject = true;
                    }
                    break;
            }
        }

        for (int i = 0; i < word.Length && !reject; ++i)
        {
            switch (clues[i])
            {
                case Clue.Unused:
                    if (used.Has(word[i]))
                    {
                        reject = true;
                    }
                    break;
            }
        }

        return reject;
    }
}
