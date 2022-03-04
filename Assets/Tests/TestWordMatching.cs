using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestWordMatching
{
    [Test]
    public void TestCorrect()
    {
        string word = "adult";
        Match match = new Match(word);
        Assert.That(match.Guess(word), Is.EqualTo("mmmmm"));
    }

    [Test]
    public void TestAbsent()
    {
        Match match = new Match("adult");
        Assert.That(match.Guess("broom"), Is.EqualTo("aaaaa"));
    }

    [Test]
    public void TestOneCorrect()
    {
        Match match = new Match("adult");
        Assert.That(match.Guess("achoo"), Is.EqualTo("maaaa"));
    }

    [Test]
    public void TestOneContained()
    {
        Match match = new Match("adult");
        Assert.That(match.Guess("maker"), Is.EqualTo("acaaa"));
    }

    [Test]
    public void TestOneOfTwoContained()
    {
        Match match = new Match("goals");
        Assert.That(match.Guess("broom"), Is.EqualTo("aacaa"));
    }

    [Test]
    public void TestOneCorrectAndOneNotContained()
    {
        Match match = new Match("goals");
        Assert.That(match.Guess("coomb"), Is.EqualTo("amaaa"));
    }

    [Test]
    public void TestOneNotContainedAndOneCorrect()
    {
        Match match = new Match("stoke");
        Assert.That(match.Guess("coomb"), Is.EqualTo("aamaa"));
    }

    [Test]
    public void TestOneCorrectAndOneContained()
    {
        Match match = new Match("woods");
        Assert.That(match.Guess("broom"), Is.EqualTo("aamca"));
    }

    [Test]
    public void TestOneContainedAndOneCorrect()
    {
        Match match = new Match("broom");
        Assert.That(match.Guess("woods"), Is.EqualTo("acmaa"));
    }
}
