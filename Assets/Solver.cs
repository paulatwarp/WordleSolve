using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Score
{
    public string word;
    public float score;
    public Score(string word, float score)
    {
        this.word = word;
        this.score = score;
    }
}

public class Solver : MonoBehaviour
{
    public Word target;
    public Word guess;
    public TextAsset wordList;
    public Slider progress;
    public Ranking topTen;
    List<string> words = new List<string>();
    List<Score> rankings = new List<Score>();

    void Start()
    {
        words.AddRange(wordList.text.Split('\n'));
        //words.RemoveRange(1000, words.Count - 1000);
        StartCoroutine(Solve());
    }

    IEnumerator Solve()
    {
        yield return null;
        var stopwath = new System.Diagnostics.Stopwatch();
        stopwath.Start();
        Match match = new Match(words[0]);
        for (int i = 0; i < words.Count; ++i)
        {
            progress.value = (float)i / (float)words.Count;
            string start = words[i];
            guess.Set(start);
            float rating = 0;
            foreach (string word in words)
            {
                match.Set(start);
                target.Set(word);
                match.Score(word);
                guess.Set(match);
                rating += Rejections(match);
                if (stopwath.ElapsedMilliseconds > 33)
                {
                    stopwath.Restart();
                    yield return null;
                }
            }

            rating = rating / (float)words.Count;
            rankings.Add(new Score(start, rating));
            rankings.Sort((a, b) => b.score.CompareTo(a.score));

            for (int j = 0; j < 10; ++j)
            {
                if (j < rankings.Count)
                {
                    Score entry = rankings[j];
                    topTen.SetRank(j, $"{entry.word} {entry.score * 100.0f}");
                }
            }
        }
    }

    float Rejections(Match match)
    {
        int rejections = 0;
        foreach (string word in words)
        {
            if (match.CanReject(word))
            {
                rejections++;
            }
        }
        return (float)rejections / (float)words.Count;
    }
}
