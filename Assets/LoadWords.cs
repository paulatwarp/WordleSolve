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

        while (true)
        {
            string hiddenWord = wordList[Random.Range(0, wordList.Count)];
            string guessWord = wordList[Random.Range(0, wordList.Count)];
            hidden.SetWord(hiddenWord);
            guess.SetWord(guessWord);

            for (int i = 0; i < hiddenWord.Length; ++i)
            {
                if (guessWord[i] == hiddenWord[i])
                {
                    guess.SetMatchedLetter(i);
                }
            }

            histogram = new Histogram(hiddenWord);
            for (int i = 0; i < 26; ++i)
            {
                Debug.Log($"{(char)('a' + i)} = {histogram.letters[i].ToString()}");
            }

            yield break;
        }
    }
}
