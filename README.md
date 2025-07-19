# UnityFramework

UnityFramework is a small sample project illustrating how to combine reactive programming with dependency injection in Unity. The project makes heavy use of **UniRx** for event driven logic and **Zenject** for dependency injection. Levels and audio assets are loaded through **Addressables**, allowing better memory management and fast iteration.

## Highlights

- **Bootstrapper** selects the chapter, preloads pool objects and sound configuration, then switches to the `Game` scene.
- **LevelManager** provides reactive APIs for loading and unloading levels by name using Addressables.
- **SoundManager** loads audio clips from Addressables and exposes simple play/loop functions.
- **EventBus** implements a message hub with UniRx to decouple game systems.
- Demonstrates DI patterns with several *Installers* configuring the runtime container.

## Getting Started

1. Install **Unity `6000.0.52f1`** or newer.
2. Clone this repository.
3. Open the project with Unity Hub and let it resolve packages in `Packages/manifest.json` (Addressables, Input System, Zenject, UniRx, etc.).
4. Open `Assets/GameAssets/Scenes/Bootstrapper.unity` and press Play.

## Directory Layout

- `Assets/GameAssets/` – Core scripts, ScriptableObjects and scenes.
- `Assets/Plugins/` – Third‑party libraries such as UniRx, Zenject and PrimeTween.
- `Packages/` – Unity package manifest specifying required packages.

## Technologies & Patterns

- **Reactive Programming** – UniRx observables drive gameplay flow.
- **Dependency Injection** – Zenject installers define how systems are wired together.
- **Addressables** – Levels and audio are loaded asynchronously to keep memory usage low.
- **Service Interfaces** – Managers expose small interfaces so components remain decoupled.

This repo is intended as a minimal showcase of these techniques rather than a complete game.
