using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 60f;
        for (int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            // set ranks based on index
            int rank = i + 1;

            entryTransform.Find("rankText").GetComponent<Text>().text = rank.ToString();

            int score = Random.Range(0, 10000);
            entryTransform.Find("nameText").GetComponent<Text>().text = score.ToString();

            string name = "MIRI";
            entryTransform.Find("scoreText").GetComponent<Text>().text = name;
        }

        /*
        // sort entries by score
        for (int i = 0; i < score.Count; i++) {
            for (int j = i + 1; j < score.Count; j++) {
                if ([j].score > score[i]) {
                    // swap
                    tmp = score[i];
                    score[i] = score[j];
                    score[j] = tmp;
                }
            }
        }
        */
    }
}
