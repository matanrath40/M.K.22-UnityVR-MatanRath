# Back To M.K 22

Welcome to "Back To M.K 22", an escape room VR game and a personal tribute to the beloved series "MK 22" (מ.ק 22). 
This game was developed as a final project for the "Unity and Virtual Reality" course under the guidance of Mr. Omri Berg, during my studies at Reichman University. 
Designed exclusively for Oculus Quest, "Back To M.K 22" challenges players with nice puzzles to save the world from an impending explosion.

## Features

- **Immersive VR Escape Room Experience:** Engage in a world inspired by the "MK 22" series, reimagined in virtual reality.
- **Challenging Riddles:** Solve three complex riddles to defuse the bomb and save the world.
- **Stunning Visuals and Effects:** Enjoy rich animations and particle effects that bring the game's environment and elements to life.
- **Optimized for Oculus Quest:** Experience seamless gameplay tailored for the Oculus Quest platform.

## Getting Started

Just download the .apk file from this url, and install on your Oculus Quest:
https://drive.google.com/file/d/1Euz-EjMeoCjMjOZ1OYWUTkHhdZD0Z-Qg/view?usp=sharing

### Prerequisites

Ensure you have the following to play "Back To M.K 22":

- Oculus Quest VR headset
- Sufficient space for safe VR play


### Gameplay (Don't watch before solving!):

https://github.com/matanrath40/M.K.22-UnityVR-MatanRath/assets/63113323/bf65e68c-a85f-40e1-b236-a06273824796

### Documentation (part of the submission of the project):

### Dev Log

#### Important Scenes:
- **MainMenu:** The first scene the user sees when opening the game. It contains three submenus:
  - **Play/Quit:** Start or exit the game.
  - **Settings:** Adjust movement settings within the VR scene.
  - **High Scores** 
- **Game:** The main game scene, featuring three riddles. Solving these riddles allows the player to access and press the red button to win the game.

#### Important Scripts:
- **CloudGeneratorScript:** Manages cloud creation and animations.
- **GameManager:** Transfers data and settings from the MainMenu to the Game scene.
- **Riddle Managers:** Each script manages the logic and behavior of its respective riddle, triggering the next one as needed.
- **Debug:** Manages the debug menu, which is only available in Editor mode.
- **Coder:** Handles the coder on the safe.

#### Bugs:
- **Game Restart Issues:** Restarting the game within the same session leads to bugs. Issues with XROrigin settings result in improper raycast functionality and occasional sticking points. A workaround is to exit the application and start it again, as there's currently no effective method to transfer XROrigin settings between the MainMenu and Game scenes.



## Acknowledgments

- Mr. Omri Berg, for his mentorship and guidance.
- The creators and community of the "MK 22" series, for inspiration.



