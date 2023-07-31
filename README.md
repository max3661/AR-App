# Vuforia-AR-App



https://github.com/max3661/Vuforia-AR-App/assets/83460693/3cc3abd9-d224-4524-a013-22afba302f0b
(Im using an older webcam to imitate a phone camera, which is why the video feed is a bit laggy)


Core Functionality: 

- Ability to scan a marker, which updates the players score and logs the markers name
- Each marker will only give points once, as there is a check for duplicates before points are added
- For testing & prototyping there is a "Reset" button in the main scene, this will reset all logged markers
- In the "FoundMarkers" scene, markers that the player found are dynamically displayed
- (This can be tested by clicking Reset, checking the "FoundMarkers" scene, then going back to the "Main" scene and scanning a marker and going back to "FoundMarkers" Scene)
- Highscore Table is displayed in the "scoreboard" scene and can be accessed by clicking the "Scoreboard"-Button in the MainScene
  - The table is currently filled with dummy data and the player data (name: Player, score is updated by the actual score)
  - For the final product we would use online data from actual players for the Highscore Tableplayers

- For this prototype, only 1 marker currently works:
  ![01](https://github.com/max3661/Vuforia-AR-App/assets/83460693/3e0639bd-2256-480a-b66a-c9f59069b502)
