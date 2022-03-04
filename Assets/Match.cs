using UnityEngine;

public class Match
{
    string target;
    // a - letter is not in the target
    // m - letter matches the target
    // c - letter is in the target as many times as c and m occur
    char [] clues;

    public Match(string target)
    {
        this.target = target;
        clues = new char[target.Length];
    }

    public string Guess(string guess)
    {
        int length = clues.Length;
        Debug.Assert(guess.Length == length);
        for (int i = 0; i < length; ++i)
        {
            clues[i] = 'a';
        }
        Histogram histogram = new Histogram(target);
        for (int i = 0; i < length; ++i)
        {
            char letter = guess[i];
            if (letter == target[i])
            {
                clues[i] = 'm';
                histogram.RemoveLetter(letter);
            }
        }
        for (int i = 0; i < length; ++i)
        {
            char letter = guess[i];
            if (clues[i] == 'a' && histogram.HasLetter(letter))
            {
                clues[i] = 'c';
                histogram.RemoveLetter(letter);
            }
        }

        return new string(clues);
    }
}
