using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score; 

    public TMP_Text textComponent;

    void Start() {
        LoadScore();
        Debug.Log(score);
    }

    private void Update() {
        textComponent.text = "Score: " + score.ToString();
    }

    public void UpdateScore() 
    {
        score += 100; 
        Debug.Log(score);
        SaveScore();
        Debug.Log("ScoreSaved");
    }

    public void SaveScore()
    {
        string savePath = Application.persistentDataPath + "/score.dat";

        // Create a data object to store the weights
        ScoreData scoreData = new ScoreData();
        scoreData.score = score;

        // Serialize the data object to a binary file
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(savePath);
        formatter.Serialize(fileStream, scoreData);
        fileStream.Close();

        Debug.Log("Score data saved.");
    }

    public void LoadScore()
    {
        string savePath = Application.persistentDataPath + "/score.dat";

        if (File.Exists(savePath))
        {
            // Deserialize the binary file to retrieve the data object
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);
            ScoreData scoreData = (ScoreData)formatter.Deserialize(fileStream);
            fileStream.Close();

            // Set the score from the loaded data object
            score = scoreData.score;

            Debug.Log("Score data loaded.");
        }
    }

    [System.Serializable]
    public class ScoreData
    {
        public int score;
    }
}
