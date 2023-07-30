using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{name = "MIRI", score = 7300},
            new HighscoreEntry{name = "BELA", score = 800},
            new HighscoreEntry{name = "MAX", score = 9800},
            new HighscoreEntry{name = "ZAKA", score = 7400}, 
            new HighscoreEntry{name = "VIKI", score = 6600}, 
            new HighscoreEntry{name = "ANNA", score = 2000}, 
            new HighscoreEntry{name = "SARAH", score = 4400}, 
            new HighscoreEntry{name = "OSCAR", score = 8000}, 
            new HighscoreEntry{name = "JONAS", score = 300},
        };

        // Sort entry list by Score
        for (int i = 0; i < highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscoreEntryList.Count; j++) {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score) {
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
        float templateHeight = 60f;
        
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
        
        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        

        transformList.Add(entryTransform);
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //Represents a single High score entry
    [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }
}
