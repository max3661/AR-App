using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using TMPro;
using System;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    [HideInInspector]
    public int score;
    private const string ScoreKey = "SavedScore";


    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        LoadScore();

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{name = "MIRI", highscore = 7300},
            new HighscoreEntry{name = "BELA", highscore = 800},
            new HighscoreEntry{name = "MAX", highscore = 9800},
            new HighscoreEntry{name = "ZAKA", highscore = 7400}, 
            new HighscoreEntry{name = "VIKI", highscore = 6600}, 
            new HighscoreEntry{name = "ANNA", highscore = 2000}, 
            new HighscoreEntry{name = "SARAH", highscore = 4400}, 
            new HighscoreEntry{name = "OSCAR", highscore = 8000}, 
            new HighscoreEntry{name = "PLAYER", highscore = score},
            new HighscoreEntry{name = "DANI", highscore = 4100},
        };

        // Sort entry list by Score
        for (int i = 0; i < highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscoreEntryList.Count; j++) {
                if (highscoreEntryList[j].highscore > highscoreEntryList[i].highscore) {
                    // Swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
        // for (int i = 0; i < 10; i++) {}   
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 90f;
        
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        // set ranks based on index
        //int rank = i + 1;
        int rank = transformList.Count + 1;

        entryTransform.Find("rankText").GetComponent<Text>().text = rank.ToString();

        // function for adding single entries (name, score) to list
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;
        
        int highscore = highscoreEntry.highscore;
        entryTransform.Find("scoreText").GetComponent<Text>().text = highscore.ToString();

        

        transformList.Add(entryTransform);
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //Represents a single High score entry
    [System.Serializable] 
    private class HighscoreEntry {
        public int highscore;
        public string name;
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0);
        Debug.Log("Score data loaded.");
    }
}
