Data Persistence Project 🎮

This is my Unity project for practicing data persistence between scenes and game sessions.

✨ Features

Player Name Input: Enter your name in the menu before starting the game.

Best Score Tracking: Keeps track of the highest score achieved.

Persistence Between Scenes: The player’s name is shown in the Main scene after starting from the Menu.

Persistence Between Sessions: Best score and player name are saved to disk and reloaded when restarting the game.

🛠️ How It Works

Implemented using a DataManager singleton with DontDestroyOnLoad.

Data is saved to a JSON file and loaded when the game starts.

MenuUIHandler and MainManager scripts manage UI and scene transitions.

🎥 Demo

Enter your name in the Menu Scene.

Press Start to play the game.

Achieve a score — if it’s higher than the previous best, it becomes the new best score.

Quit and restart the game — the Best Score is still saved!

📂 Repository Notes

Built with Unity 2020.3.7f1 (LTS).

Includes Assets/, Packages/, and ProjectSettings/ folders.
