using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWords : MonoBehaviour
{
    public TextAsset words;
    public Word word;
    List<string> wordList;

    private void Start()
    {
        wordList = new List<string>(words.text.Replace("\r\n", "\n").Split('\n'));
        word.SetWord(wordList[Random.Range(0, wordList.Count)]);
    }
}
