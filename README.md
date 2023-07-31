# Vuforia-AR-App


Core Functionality: 

- Ability to scan a marker, which updates the players score and logs the markers name
- Each marker will only give points once, as there is a check for duplicates before points are added
- For testing & prototyping there is a "Reset" button in the main scene, this will reset all logged markers
- In the "FoundMarkers" scene, markers that the player found are dynamically displayed
- (This can be tested by clicking Reset, checking the "FoundMarkers" scene, then going back to the "Main" scene and scanning a marker and going back to "FoundMarkers" Scene)
- Highscore Table is displayed in the "scoreboard" scene and can be accessed by clicking the "Scoreboard"-Button in the MainScene
  - table is currently filled with dummy data and the player data (name: Player, score is updated by the actual score)
  - for the final product we would use online data from actual players for the Highscore Tableplayers

- For this prototype, only 1 marker currently works:
  ![01](https://github.com/max3661/Vuforia-AR-App/assets/83460693/3e0639bd-2256-480a-b66a-c9f59069b502)
