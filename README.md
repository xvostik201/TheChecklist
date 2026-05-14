<div align="center">
  
#  🛰️ The Checklist 

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Unity](https://img.shields.io/badge/Unity-2022.3-black?logo=unity)
![Zenject](https://img.shields.io/badge/DI-Zenject-green?logo=unity)
![DOTween](https://img.shields.io/badge/Animation-DOTween-orange)

**Data-driven framework for realistic aircraft cockpit interactions with intelligent checklist, rollback mechanics and cinematic finale.**

[![Watch Demo](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/PlaneCockpitFinal.png)](https://www.youtube.com/watch?v=fDp7lWHwGHg)

*From cold start → complete checklist → cinematic takeoff sequence.*

</div>

---

### ✨ Key Features

- **Data-Driven Cockpit Elements** — Buttons, Levers, Dragging handles and Interactive Clipboard, fully configured via ScriptableObjects
- **Intelligent Checklist System** with automatic **rollback** — incorrect actions on previous steps reset progress
- **Clean Architecture** powered by **Zenject** (Dependency Injection) and interface-based design
- **ElementRegistry** — automatic registration and lookup of all interactive objects
- **Smooth Animations** using DOTween with configurable duration, easing and drag sensitivity
- **Cinematic Ending** — seamless Unity Timeline sequence triggers after successful checklist completion
- **Audio Pooling** with 3D spatial sound and randomized pitch/volume
- **Dynamic Camera** with reduced sensitivity during interactions
- **Extensible Design** — adding new controls or even another aircraft requires minimal code changes

---

### 🛠️ Evolution of the Project

#### Stage 1: Core Mechanics & Whitebox Prototype
![Whitebox](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/MainImage.png)  
Focused on reliable interaction logic, different element types, normalized dragging and the foundation of Zenject + ElementRegistry.

#### Stage 2: Cockpit Integration
![PlaneCockpit](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/PlaneCockpit.png)  
All systems integrated into the aircraft interior. Validated full interaction between input, checklist, audio and visuals.

#### Stage 3: Final Polish & Cinematic Experience (Current)
![FinalBuild](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/PlaneCockpitFinal.png)  
Complete visual overhaul, detailed environment, interactive clipboard with pagination, and polished Unity Timeline cinematic sequence.

---

### 🎬 Demonstrations

<div align="center">

![Demo 1](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/MainGif0.gif)
![Demo 2](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/MainGif1.gif)

*Real-time cockpit interaction showcasing smooth animations, element feedback, and checklist progression.*

</div>

---

### 🧩 Technical Highlights

- **Architecture**: Strict separation of concerns using Zenject Installers, Interfaces (`IInteractable`, `IToggleableElement`, `INormalizedElement`) and centralized `ElementRegistry`
- **State Management**: `ChecklistManager` with real-time validation and intelligent rollback logic
- **Interaction System**: Raycast-based input with special handling for dragging mechanics
- **Data Layer**: All behavior (limits, sensitivity, animations, audio) defined in ScriptableObjects
- **Performance**: Audio object pooling and optimized update loops
- **Testing**: NUnit unit test for normalized value calculations

---

### 📦 Core Systems Overview

#### **Cockpit Elements**

<div align="center">

**Button** — Interactive button with press animation and state toggle

![Button](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/Button.png)

</div>

Fully configurable via `CockpitElementData` with customizable press depth and animation duration.

---

<div align="center">

**Lever** — Rotatable lever that can be toggled on/off with smooth animation

![Lever](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/Lever.png)

</div>

Supports target rotation angles with easing curves for realistic mechanical feedback.

---

<div align="center">

**Dragging** — Normalized dragging handle with min/max rotation constraints

![Drag](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/Drag.png)

</div>

Produces normalized values (0-1) perfect for throttle controls and proportional inputs.

---

**Clipboard** — Interactive clipboard with checklist display and pagination  
Digital checklist showing completed (green), current (red), and upcoming (yellow) steps with page navigation.

---

#### **Plane Systems**

- **PowerSystem** — Manages aircraft power state with visual feedback on power button via emission materials
- **EngineSystem** — Controls engine audio with RPM progression, pitch variation, and continuous camera shake effects
- **CanopySystem** — Manages cockpit glass opening/closing with emission effects and audio frequency filtering
- **BrakeSystem** — Handles brake state with emission-based visual feedback tied to power state
- **RadarSystem** — Controls radar display with dynamic intensity animations and power dependency
- **TakeoffSequence** — Orchestrates cinematic takeoff with G-force camera effects, shake, and Timeline integration

---

#### **Player Systems**

- **PlayerInteractable** — Manages raycast-based interaction with cockpit elements, drag detection, and sequence validation
- **CameraRotation** — Free-look camera with adjustable sensitivity and lock-out during shake effects
- **CameraZoom** — Mouse scroll-based FOV adjustment with smooth lerp interpolation
- **CameraShaking** — Feedback system for invalid actions and continuous engine vibration based on RPM
- **InputManager** — Centralized input handling using Unity's New Input System

---

#### **Checklist Management**

- **ChecklistManager** — Core system handling step progression, validation, and intelligent rollback logic
- **ChecklistStep** — Configurable checklist step with persistence settings for rollback mechanics
- **ElementRegistry** — Automatic discovery and lookup of interactive elements by ID

---

### 📸 Configuration Examples

<div align="center">

#### Audio System Configuration
![Audio Data](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/AudioDataSO.png)

*Centralized audio clip management with volume and pitch settings per element.*

#### Checklist Step Configuration
![Checklist Step](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/ChecklistStepSO.png)

*Element-specific step configuration with required state/value and persistence settings.*

#### Timeline for Cinematic Sequence
![Timeline](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/CompleteChecklistTimeline.png)

*Unity Timeline setup for smooth cinematic sequence triggered on checklist completion.*

</div>

---

### 🚁 Aircraft Gallery

<div align="center">

#### F4 Phantom (Default State)
![F4 Phantom](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/F4Phantom.png)

Cold cockpit with all systems offline, ready for pre-flight checklist.

#### F4 Phantom (Powered Up)
![F4 Phantom Powered](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/F4PhantomPowered.png)

Aircraft with power systems activated, all cockpit elements illuminated and ready for engine startup.

</div>

---

### 🎮 How to Play

<div align="center">

![Main Menu](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/MainMenuScene.png)

**Select Your Aircraft**
- 🛩️ **F4 Phantom** → Carrier-based fighter jet
- ✈️ **Boeing** → Commercial airliner

</div>

**Game Controls:**
1. **Left Mouse Button** — Interact with cockpit elements
2. **Mouse Movement** — Look around (sensitivity decreases while dragging)
3. **Mouse Scroll** — Adjust camera zoom (FOV)
4. Complete all checklist steps in the correct order
5. Upon completion — automatic cinematic takeoff sequence begins
6. Press **Space** in the credits scene to quit

**Gameplay Mechanics:**
- The system actively prevents sequence breaking
- Attempting to use elements out of order triggers camera shake feedback
- Persistent steps trigger rollback if their state changes incorrectly
- Normalized elements (dragging) must reach specific values within ±5% tolerance

---

### 🧪 Testing & Debugging

<div align="center">

#### Normalized Value Testing
![Normalized Test](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/NormalizedTest.png)

*NUnit unit tests verify normalized value calculations for dragging mechanics.*

#### Checklist Debug Log
![Debug Log](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/ChecklistDebugLog.png)

*Real-time console output showing all registered checklist steps and their target elements.*

#### Rollback Mechanism
![Rollback Log](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Project/Documentation/DebugRollbackLog.png)

*Detailed logging of rollback events when persistent steps are violated, with step index and descriptions.*

</div>

---

### 🛠️ Technologies Used

- **Unity 2022.3**
- **Zenject** — Dependency Injection Framework
- **New Input System** — Modern input handling
- **DOTween** — Tweening and animations
- **Unity Timeline + Cinemachine** — Cinematic sequences and camera control
- **TextMeshPro** — Advanced UI text rendering
- **NUnit** — Unit testing framework
- **ScriptableObjects** — Data-driven configuration
- **Universal Render Pipeline (URP)** — Modern rendering pipeline
- **ShaderLab** — Custom shader effects (water, emission)

---

### 📁 Project Structure

```bash
Assets/_Project/Scripts/
├── Core/
│   ├── Managers/
│   │   ├── CreditSceneManager.cs      # Handles credit scene input and quit
│   │   └── SceneEndingManager.cs      # Triggers cinematic on checklist complete
│   └── Services/
│       └── UnityAudioService.cs       # Audio pooling and 3D spatial sound
│
├── Data/
│   ├── AudioClipData.cs               # Individual audio clip configuration
│   ├── AudioRegistry.cs               # Centralized audio management
│   └── GeneralSettingsData.cs         # Global game settings
│
├── Features/
│   ├── Aircraft/
│   │   ├── PlaneBase.cs               # Base class for aircraft
│   │   └── F4Phantom/
│   │       └── F4_Phantom.cs          # F4 Phantom implementation
│   │
│   ├── Checklist/
│   │   ├── ChecklistManager.cs        # Core checklist logic and rollback
│   │   └── ChecklistStep.cs           # Step configuration ScriptableObject
│   │
│   ├── Cockpit/
│   │   ├── Data/
│   │   │   ├── CockpitElementData.cs  # Element configuration
│   │   │   └── CockpitElementType.cs  # Element type enum
│   │   │
│   │   ├── Elements/
│   │   │   ├── BaseCockpitElement.cs  # Base class for all elements
│   │   │   ├── Button.cs              # Button implementation
│   │   │   ├── Lever.cs               # Lever implementation
│   │   │   ├── Dragging.cs            # Dragging/normalized element
│   │   │   └── Clipboard/
│   │   │       ├── Clipboard.cs       # Interactive clipboard
│   │   │       └── ClipboardButton.cs # Clipboard navigation buttons
│   │   │
│   │   └── Systems/
│   │       ├── PowerSystem.cs         # Power management
│   │       ├── EngineSystem.cs        # Engine audio and RPM
│   │       ├── EngineAudioGroup.cs    # Engine audio configuration
│   │       ├── CanopySystem.cs        # Cockpit glass mechanics
│   │       ├── BrakeSystem.cs         # Brake system
│   │       ├── RadarSystem.cs         # Radar display
│   │       └── TakeoffSequence.cs     # Cinematic takeoff
│   │
│   ├── Environment/
│   │   └── AircraftCarrier/
│   │       └── CharlesDeGulllis.cs    # Carrier animation
│   │
│   └── Player/
│       ├── Input/
│       │   └── InputManager.cs        # Centralized input handling
│       │
│       ├── CameraRotation.cs          # Free-look camera
│       ├── CameraZoom.cs              # Camera FOV adjustment
│       ├── CameraShaking.cs           # Camera shake effects
│       └── PlayerInteractable.cs      # Interaction manager
│
├── Infrastructure/
│   ├── ElementRegistry.cs             # Element registration system
│   ├── SceneLoader.cs                 # Scene loading utility
│   └── Installers/
│       ├── AudioInstaller.cs          # Audio system DI
│       ├── CameraInstaller.cs         # Camera system DI
│       ├── ChecklistInstaller.cs      # Checklist system DI
│       ├── ElementInstaller.cs        # Element registry DI
│       ├── GeneralSettingsInstaller.cs # Settings DI
│       ├── InputInstaller.cs          # Input system DI
│       ├── InteractableInstaller.cs   # Interaction system DI
│       └── PlaneSystemInstaller.cs    # Aircraft systems DI
│
├── Interfaces/
│   ├── IAudioProvider.cs              # Audio interface
│   ├── IInteractable.cs               # Interactable interface
│   ├── IToggleableElement.cs          # Toggle element interface
│   └── INormalizedElement.cs          # Normalized element interface
│
├── Editor/
│   └── CockpitElementEditor.cs        # Custom inspector for elements
│
├── UI/
│   └── MenuScene.cs                   # Main menu handler
│
└── Tests/
    └── Editor/
        └── DraggingTest.cs            # NUnit tests for normalization
```

---

### 🔧 Key Scripts Reference

#### Core Game Loop
- `ChecklistManager.cs` — Handles step progression, validation, and rollback on persistent element changes
- `PlayerInteractable.cs` — Raycasts for interactions and manages dragging state

#### Audio System
- `UnityAudioService.cs` — Object pooling of AudioSources with randomized pitch/volume
- `AudioRegistry.cs` — Dictionary-based lookup of audio clips by ID
- `AudioClipData.cs` — Individual clip configuration (volume, ID)

#### Settings & Configuration
- `GeneralSettingsData.cs` — Mouse sensitivity, drag resistance, zoom range
- `CockpitElementData.cs` — Per-element animation, rotation, audio settings
- `CockpitElementType.cs` — Enum: Button, Lever, Dragging, Clipboard

#### Infrastructure
- `ElementRegistry.cs` — O(1) element lookup by string ID
- `SceneLoader.cs` — Static scene management utility
- **Installers** — Zenject bindings for DI container setup

---

### 🚀 Installation

**Option 1: Clone from GitHub**
```bash
git clone https://github.com/xvostik201/TheChecklist.git
cd TheChecklist
```

**Option 2: Download Release**
Download: [TheChecklist_v1.0-takeoff-demo.rar](https://github.com/xvostik201/TheChecklist/releases/tag/v0.1-takeoff-demo)

Extract and run the `.exe` directly, or:

**To Run in Unity Editor:**
1. Open the project in **Unity 2022.3 LTS** or later
2. Load the main scene: `Assets/_Project/Scenes/MainScene.unity`
3. Press **Play**

**No additional setup required.** All ScriptableObjects and Installers are pre-configured.

---

### 🔄 Data Flow & Architecture

```
┌─────────────────────┐
│   InputManager      │ ← Reads Unity Input System
└──────────┬──────────┘
           │
           ↓
┌─────────────────────┐
│ PlayerInteractable  │ ← Raycasts for interactions
└──────────┬──────────┘
           │
           ↓
┌─────────────────────────────────────┐
│   CockpitElement (Button/Lever...)  │ ← Changes state
└──────────┬────────────────────────┬─┘
           │                        │
           ↓                        ↓
┌────────────────────┐    ┌──────────────────────┐
│ ChecklistManager   │    │ AudioProvider        │
│  (validates step)  │    │ (plays 3D/2D sounds) │
└────────┬───────────┘    └──────────────────────┘
         │
         ↓
┌─────────────────────────────┐
│ OnChecklistComplete event   │ ← Triggers cinematic
└─────────────────────────────┘
```

---

### 🎯 Rollback Mechanics

The `ChecklistManager` monitors **all** previous steps' elements:

1. ✅ Player completes steps 1-5
2. ❌ Player accidentally toggles Step 3 element incorrectly
3. 🔄 System detects violation and **resets to step 3**
4. ⚠️ Console logs rollback event with step details

Only **persistent** steps trigger rollback (configurable per step).

---

### 📊 Performance Considerations

- **Audio Pooling**: 10+ AudioSources reused instead of instantiated per play
- **Element Lookup**: O(1) dictionary-based registry lookup
- **Reduced Sensitivity**: Camera rotation sensitivity disabled during dragging
- **Update Loop**: Only active systems run Update; disabled systems culled
- **Timeline**: Cinemachine handles camera during cutscenes (no competing inputs)

---

### 🤝 Contributing

This is a personal portfolio project showcasing game architecture, DI patterns, and cockpit simulation design. Feel free to fork and experiment!

---

<div align="center">

📜 **License** — MIT  
📮 **Contact** — [zkostyutkin2004@gmail.com](mailto:zkostyutkin2004@gmail.com)  
💼 **LinkedIn** — [Connect with me](https://www.linkedin.com/in/zakhar-kostyutkin-b2740b393/)

👤 **Author** — Zakhar Kostyuktin (xvostik201)  

**Made with passion for flight simulation, clean code, and realistic cockpit interactions.**

</div>