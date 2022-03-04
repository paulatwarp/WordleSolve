using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWords : MonoBehaviour
{
    public TextAsset words;
    public Word hidden;
    public Word guess;
    List<string> wordList;
    public Histogram histogram;

    IEnumerator Start()
    {
        wordList = new List<string>(words.text.Replace("\r\n", "\n").Split('\n'));
        string hiddenWord = wordList[12361];//Random.Range(0, wordList.Count)];
        hidden.SetWord(hiddenWord);

        Match match = new Match(hiddenWord);
        while (true)
        {
            string guessWord = wordList[Random.Range(0, wordList.Count)];

            guess.SetWord(guessWord);
            string clues = match.Guess(guessWord);

            for (int i = 0; i < clues.Length; ++i)
            {
                Color color = Color.grey;
                switch (clues[i])
                {
                    case 'a':
                        color = Color.grey;
                        break;
                    case 'c':
                        color = Color.yellow;
                        break;
                    case 'm':
                        color = Color.green;
                        break;
                }
                guess.SetMatchedLetter(i, color);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
    }
}
