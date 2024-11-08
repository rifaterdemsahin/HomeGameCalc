# HomeGameCalc

## Overview

HomeGameCalc is a Unity project that includes various scripts and assets to facilitate mobile and cross-platform game development. This project leverages Unity's standard assets and custom scripts to provide a comprehensive toolkit for game developers.

## Project Structure

### Assets

- **Standard Assets**
    - **Utility**
        - `AutoMobileShaderSwitch.cs`: Manages shader replacements for mobile platforms.
        - `TimedObjectActivator.cs`: Activates objects based on a timer.
        - `WaypointCircuit.cs`: Manages waypoints for path-following objects.
        - `SimpleMouseRotator.cs`: Provides simple mouse rotation functionality.
        - `ParticleSystemDestroyer.cs`: Destroys particle systems after a certain time.
        - `PlatformSpecificContent.cs`: Enables or disables content based on the platform.
    - **CrossPlatformInput**
        - `MobileControlRig.cs`: Manages mobile control rigs.
        - `TiltInput.cs`: Manages tilt input on mobile devices.
        - `CrossPlatformInputInitialize.cs`: Initializes cross-platform input settings.
        - **Prefabs**
            - `MobileSingleStickControl.prefab`: Prefab for single stick mobile control.
            - `MobileAircraftControls.prefab`: Prefab for aircraft controls on mobile.
        - **Scripts**
            - Various scripts to manage mobile input and control rigs.
    - **Fonts**
        - `LuckiestGuy`: Font used in the project with its respective license.

### Editor

- **CrossPlatformInput**
    - `CrossPlatformInputInitialize.cs`: Initializes cross-platform input settings in the editor.

### Example Games

- **2D Scrolling Shooter**
    - `_ReadMe.txt`: Instructions and additional elements for the 2D scrolling shooter game.

### WoLfulus

- **UI**
    - **Modal**
        - `Docs/Documentation.md`: Documentation for creating modal dialogs.

## License

This project is licensed under the GNU General Public License. For more details, refer to the `LICENSE` file.

## Getting Started

To get started with HomeGameCalc, follow these steps:

1. Clone the repository.
2. Open the project in Unity.
3. Explore the assets and scripts to understand their functionality.
4. Customize and extend the project as needed for your game development needs.

For more information, refer to the documentation provided in the project.
