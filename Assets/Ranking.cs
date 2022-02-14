using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Text prefab;
    List<Text> ranks = new List<Text>();

    void Start()
    {
        for (int i = 0; i < 10; ++i)
        {
            ranks.Add(Instantiate(prefab, transform));
        }
    }

    public void SetRank(int rank, string text)
    {
        ranks[rank].text = text;
    }
}
