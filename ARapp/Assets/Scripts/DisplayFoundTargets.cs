using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayFoundTargets : MonoBehaviour
{
    public Transform contentParent;

    private void Awake()
    {
        DisplayImagesOfFoundTargets();
    }

    private void DisplayImagesOfFoundTargets()
    {
        string[] foundTargetNames = LoadFoundTargetNames();

        foreach (string targetName in foundTargetNames)
        {
            Sprite targetSprite = LoadSpriteForTarget(targetName);
            if (targetSprite != null)
            {
                GameObject imageObject = new GameObject("Image_" + targetName);
                Image imageComponent = imageObject.AddComponent<Image>();
                imageObject.transform.SetParent(contentParent, false);


                imageComponent.sprite = targetSprite;
            }
        }
    }

    // Function to load the target names from PlayerPrefs or other data storage
    private string[] LoadFoundTargetNames()
    {
        string targetNamesString = PlayerPrefs.GetString("FoundTargetNames", "");

        string[] foundTargetNames = targetNamesString.Split(',');

        foundTargetNames = Array.FindAll(foundTargetNames, name => !string.IsNullOrEmpty(name));

        Debug.Log("Target Names loaded ");
        return foundTargetNames;
    }

    private Sprite LoadSpriteForTarget(string targetName)
    {
        string spritePath = "Sprites/" + targetName;

        Sprite targetSprite = Resources.Load<Sprite>(spritePath);

        if (targetSprite == null)
        {
            Debug.LogWarning("Sprite for target " + targetName + " not found in 'Sprites' folder.");
        }

        return targetSprite;
    }
}