using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList
{
    readonly int size;
    readonly HashSet<string> words;
    readonly HashSet<string> [,] wordsWithLetterCount;
    readonly HashSet<string> [,] wordsWithLetterPlace;

    public static int CountLetter(string word, char letter)
    {
        int count = 0;
        foreach (char c in word)
        {
            if (c == letter)
            {
                ++count;
            }
        }
        return count;
    }

    public WordList(IEnumerable<string> list)
    {
        words = new HashSet<string>(list);
        Debug.Assert(words.Count > 0, "must supply a non-empty list");
        size = 5;//
        wordsWithLetterPlace = new HashSet<string> [size, Histogram.alphabet];
        wordsWithLetterCount = new HashSet<string> [size + 1, Histogram.alphabet];
        for (int a = 0; a < Histogram.alphabet; ++a)
        {
            for (int i = 0; i < size; ++i)
            {
                wordsWithLetterPlace[i, a] = new HashSet<string>();
            }

            for (int i = 0; i < size + 1; ++i)
            {
                wordsWithLetterCount[i, a] = new HashSet<string>();
            }
        }

        foreach (string word in words)
        {
            for (int i = 0; i < size; ++i)
            {
                wordsWithLetterPlace[i, Histogram.IndexFromLetter(word[i])].Add(word);
            }
        }

        foreach (string word in words)
        {
            for (char a = 'a'; a <= 'z'; ++a)
            {
                int count = CountLetter(word, a);
                wordsWithLetterCount[count, Histogram.IndexFromLetter(a)].Add(word);
            }
        }
    }

    public HashSet<string> AllWords()
    {
        return words;
    }

    public HashSet<string> WordsWithLetterInPlace(char c, int position)
    {
        return wordsWithLetterPlace[position, Histogram.IndexFromLetter(c)];
    }

    public HashSet<string> WordsWithLetterCount(char c, int count)
    {
        return wordsWithLetterCount[count, Histogram.IndexFromLetter(c)];
    }
}
