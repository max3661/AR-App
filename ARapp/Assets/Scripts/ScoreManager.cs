using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using TMPro;
using Vuforia;
using System;

public class ScoreManager : MonoBehaviour
{
 

    public TMP_Text textComponent;
    public GameObject imageTargetObject;
    private ImageTargetBehaviour imageTargetBehaviour;

    private string[] foundTargetNames = new string[0];

    [HideInInspector]
    public int score; 
    private const string ScoreKey = "SavedScore";

    void Start() {
        // find image target behavior component from ImageTarget gameobj
        imageTargetBehaviour = imageTargetObject.GetComponent<ImageTargetBehaviour>();

        // Check if the component was found
        if (imageTargetBehaviour == null)
        {
            Debug.LogError("ImageTargetBehaviour component error");
            // Add future error handling here
        }

        LoadScore();
        LoadFoundTargetNames();
    }

    private void Update() {
        textComponent.text = "Score: " + score.ToString();
    }

    public void OnFound() 
    {   
        // Call the function to log current target name
        LogTargetName(imageTargetBehaviour.TargetName);
    }

    private void LogTargetName(string targetName)
    {

        if (ArrayContainsTargetName(targetName))
        {
            Debug.Log(targetName + " is already present in the array");
            return; 
        }

        // Resize the array to accommodate the new target name
        System.Array.Resize(ref foundTargetNames, foundTargetNames.Length + 1);

        // Save the current target name at the last index of the array
        foundTargetNames[foundTargetNames.Length - 1] = targetName;

        // Debug log the saved target name
        Debug.Log("Saved Target Name: " + targetName);
        PrintAllTargetNames();

        UpdateScore();
        SaveFoundTargetNames();
    }

    private bool ArrayContainsTargetName(string targetName)
    {
        return Array.Exists(foundTargetNames, name => name == targetName);
    }

    private void UpdateScore() 
    {   
        // increment score by X value
        score += 100; 
        SaveScore();
    }

    // Function to print all the target names in the array
    private void PrintAllTargetNames()
    {
        Debug.Log("All Saved Target Names:");
        foreach (string targetName in foundTargetNames)
        {
            Debug.Log(targetName);
        }
    }

    // Function to delete the contents of the array for testing purposes
    public void DeleteArrayContents()
    {
        foundTargetNames = new string[0];
        PlayerPrefs.DeleteKey("FoundTargetNames");
        Debug.Log("Array contents deleted for testing purposes.");
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, score);
        PlayerPrefs.Save();
        Debug.Log("Score data saved.");
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt(ScoreKey, 0);
        Debug.Log("Score data loaded.");
    }

    // Function to save the array to PlayerPrefs
    private void SaveFoundTargetNames()
    {
        // Join the array elements into a single string with a separator
        string targetNamesString = string.Join(",", foundTargetNames);

        // Save the concatenated string to PlayerPrefs
        PlayerPrefs.SetString("FoundTargetNames", targetNamesString);
    }

    // Function to load the array from PlayerPrefs
    private void LoadFoundTargetNames()
    {
        // Retrieve the concatenated string from PlayerPrefs
        string targetNamesString = PlayerPrefs.GetString("FoundTargetNames", "");

        // Split the string into individual elements using the separator
        foundTargetNames = targetNamesString.Split(',');

        // Remove any empty entries resulting from the split
        foundTargetNames = Array.FindAll(foundTargetNames, name => !string.IsNullOrEmpty(name));
    }
}
