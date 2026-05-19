# Project Overview: Unity 3D Tower Defense (UWP Project)

This is a 3D Tower Defense project developed in Unity. It features a phase-based gameplay loop (Construction and Defense), enemy wave management, and a decoupled event-driven architecture.

## Core Technologies
- **Unity Version:** 6 (6000.2.11f1)
- **Render Pipeline:** Universal Render Pipeline (URP)
- **Key Packages:**
  - AI Navigation (`com.unity.ai.navigation`)
  - Input System (`com.unity.inputsystem`)
  - Splines (`com.unity.splines`)
  - TextMesh Pro (`com.unity.ugui`)

## Architecture & Patterns
- **Singleton Pattern:** Used for global managers (`GameManager`, `SignalBus`, `WaveManager`, `CoinsManager`, `EnemyPool`, `BulletPool`).
- **Signal Bus:** An event-driven system using `UnityEvent` for decoupled communication between game systems (e.g., phase transitions).
- **MVP (Model-View-Presenter):** Employed for UI elements, specifically health bars (e.g., `BaseHealth`, `HealthBar`, `HealthPresenter`).
- **Object Pooling:** Optimized spawning for frequently created/destroyed objects like bullets and enemies (`BulletPool`, `EnemyPool`).
- **State Machine:** Available in `Abstraction` for complex state logic, though not extensively seen in core managers yet.

## Project Structure
- `Assets/Scripts/Managers/`: Orchestration logic (`GameManager`, `WaveManager`, `SignalBus`, etc.).
- `Assets/Scripts/Core/`: Base game logic like health and factories.
- `Assets/Scripts/AI/`: Enemy behavior and movement.
- `Assets/Scripts/Tower/`: Tower logic, bullet behavior, and configurations.
- `Assets/Scripts/Abstraction/`: Generic base classes (Singletons, Factories, State Machines).
- `Assets/Scripts/Presenters/`: UI logic bridging models and views.
- `Assets/Scripts/UI/`: View components and health bars.

## Development Conventions
- **Namespaces:** Code is organized into logical namespaces (`Managers`, `AI`, `Core`, `Abstraction`, `Presenters`, `UI`).
- **Coding Style:**
  - PascalCase for class and method names.
  - camelCase for private fields (some use `[SerializeField]`).
  - Use `SignalBus` for global events like "DefensePhaseStarted" and "ConstructionPhaseStarted".
- **Performance:** Always use `ObjectPool` for bullets and enemies to avoid garbage collection spikes.
- **UI:** Prefer MVP pattern for complex UI interactions to keep logic separate from Unity's View components.

## Building and Running
1. Open the project in **Unity 6 (6000.2.11f1)**.
2. The main scene is likely located in `Assets/Scenes/`.
3. Press **Play** in the Unity Editor to run.
4. **TODO:** Document automated build steps or CI/CD if implemented.

## Key Files
- `Assets/Scripts/Managers/GameManager.cs`: Controls the main game flow.
- `Assets/Scripts/Managers/SignalBus.cs`: Central hub for global events.
- `Assets/Scripts/Managers/WaveManager.cs`: Manages enemy spawning logic.
- `Assets/Scripts/Tower/Tower.cs`: Main tower logic (targeting, shooting).
- `Assets/Scripts/AI/Enemy.cs`: Enemy stats and lifecycle.
