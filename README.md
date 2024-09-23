# AlienPopper

### Atrribution for soldier sprite sheet: https://craftpix.net/freebies/free-soldier-sprite-sheets-pixel-art/
### Attribution for background image: <a href="https://www.freepik.com/free-vector/arcade-game-world-pixel-scene_4814928.htm#position=1">Image by stockgiu</a> on Freepik
### Attribution for background music: https://www.fesliyanstudios.com/royalty-free-music/download/retro-platforming/454
### Attribution for pop sound effect: https://pixabay.com/sound-effects/pop2-84862/
### Balloon Pop sprite sheet: https://opengameart.org/content/balloon-pop-sprite
### AlienPopper Game: https://pending.itch.io/feng-he-victor-alien-popper

## About The Project
![image](https://github.com/user-attachments/assets/4e54dc9d-ecf8-47f7-9375-2fe8d1c4be8c)

Alien Popper is a 2D game built using Unity. The game leverages various Unity frameworks and modules to provide a seamless gaming experience with interactive 2D physics, particle effects, and scripted visual elements. This README will guide you through the setup process, as well as provide insights into the technologies used and how to contribute to the project.

## Table of Contents
* [Project Overview](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#project-overview)
* [Features](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#features)
* [Technologies](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#technologies)
* [Installation](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#installation)
* [Usage](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#usage)
* [Contributing](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#contributing)
* [License](https://github.com/victor-feng-he/AlienPopper/blob/main/README.md#license)

## Project Overview
Alien Popper is a 2D platforming game where players shoot at alien balloons for points as they navigate through three game levels, with each one having different obstacles to bypass to get within shooting range of balloons. The game also features a scoreboard that stores the player's name and points in a JSON database, which is saved in-between sessions. With smooth visuals, reactive physics, and custom scripting, the game provides an engaging and dynamic environment for players of all ages.

## Features
* 2D Gameplay: Built with Unity's 2D system, using tilemaps and 2D physics.
* Visual Scripting: No-code support through Unity Visual Scripting.
* Interactive UI: Leveraging Unity's UI system (UGUI) for clean and responsive user interfaces.
* Particle Effects: Dynamic particle systems for explosions and environment effects.

## Technologies
The project is built using Unity Engine, utilizing the following major frameworks and modules:

### Unity Core:

* Unity 2D System (com.unity.feature.2d@2.0.0): For 2D gameplay and physics.
* Unity Test Framework (com.unity.test-framework@1.1.33): Ensuring game stability through automated tests.
* Unity UI (com.unity.ugui@1.0.0): Used for game menus and HUD elements.
* Unity Timeline (com.unity.timeline@1.7.5): For cutscene and timeline management.
* TextMeshPro (com.unity.textmeshpro@3.0.6): High-quality text rendering for in-game UI.
* Visual Scripting (com.unity.visualscripting@1.9.1): No-code development tool for interactive scripting.

### Additional Unity Modules:

* 2D Physics (com.unity.modules.physics2d@1.0.0): For handling game object collisions and physics interactions.
* Particles System (com.unity.modules.particlesystem@1.0.0): Used for particle effects like explosions.
* XR Modules (com.unity.modules.xr@1.0.0): VR/XR support.

### Development Tools:

* IDE integrations for JetBrains Rider and Visual Studio, making it easy to work with both editors.

## Installation

1. Clone the repository:
```
git clone https://github.com/yourusername/alien-popper.git
```
2. Open the project in Unity:

* Download and install Unity Hub.
* Add this project to Unity Hub by selecting the project folder (Feng He + Victor + Alien Popper) from your local directory.
* Ensure you are using the correct Unity version, as specified in ProjectVersion.txt.
* Install dependencies: Unity should automatically download and install the necessary packages listed in the dependencies.txt file when opening the project.

3. Build and Run:

* To test the game, press the Play button in the Unity Editor.
* For building the game, go to File > Build Settings, select your target platform (e.g., Windows, Android), and click Build.

## Usage
1. Game Controls:

* Basic keyboard/mouse controls will depend on the setup in the game.
* Use the WASD keys to move and mouse clicks to aim to shoot projectiles.

2. Customization:

* Modify scenes or assets by navigating to the appropriate folder within Unity.
* Scripts and behaviors can be customized via Unity's Visual Scripting tool or by directly editing C# scripts.

## Contributing
Feel free to make any changes or additions to Alien Popper! If you'd like to add new features, fix bugs, or improve performance, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes.
4. Push your changes to your fork and submit a pull request.

You can also refer to this documentation file for more details: https://github.com/victor-feng-he/AlienPopper/blob/main/Alien%20Popper%20Documentation.pdf
## License
This project is licensed under the Personal License.
