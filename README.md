<div align="center">
  
#  🛰️ The Checklist 

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Unity](https://img.shields.io/badge/Unity-2022.3-black?logo=unity)
![Zenject](https://img.shields.io/badge/DI-Zenject-green?logo=unity)
![DOTween](https://img.shields.io/badge/Animation-DOTween-orange)

**Data-driven framework for realistic aircraft cockpit interactions with intelligent checklist, rollback mechanics and cinematic finale.**

[![Watch Demo](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/PlaneCockpitFinal.png)](https://www.youtube.com/watch?v=fDp7lWHwGHg)

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
![Whitebox](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/MainImage.png)  
Focused on reliable interaction logic, different element types, normalized dragging and the foundation of Zenject + ElementRegistry.

#### Stage 2: Cockpit Integration
![PlaneCockpit](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/PlaneCockpit.png)  
All systems integrated into the aircraft interior. Validated full interaction between input, checklist, audio and visuals.

#### Stage 3: Final Polish & Cinematic Experience (Current)
![FinalBuild](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/PlaneCockpitFinal.png)  
Complete visual overhaul, detailed environment, interactive clipboard with pagination, and polished Unity Timeline cinematic sequence.

---

### 🧩 Technical Highlights

- **Architecture**: Strict separation of concerns using Zenject Installers, Interfaces (`IInteractable`, `IToggleableElement`, `INormalizedElement`) and centralized `ElementRegistry`
- **State Management**: `ChecklistManager` with real-time validation and intelligent rollback logic
- **Interaction System**: Raycast-based input with special handling for dragging mechanics
- **Data Layer**: All behavior (limits, sensitivity, animations, audio) defined in ScriptableObjects
- **Performance**: Audio object pooling and optimized update loops
- **Testing**: NUnit unit test for normalized value calculations

---

### 📸 Configuration Examples

| Cockpit Element | Checklist Step | Audio Registry |
| :---: | :---: | :---: |
| ![Button Data](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Button.png) | ![Checklist Step](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/StepSO.png) | ![Audio Data](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/AudioDataSO.png) |

*All interactive elements are fully configurable without code changes.*

---

### 🎮 How to Play

1. **Left Mouse Button** — Interact with cockpit elements
2. **Mouse Movement** — Look around (sensitivity decreases while dragging)
3. Complete all checklist steps in the correct order
4. Upon completion — automatic cinematic takeoff sequence begins
5. Press **Space** in the credits scene to quit

> The system actively prevents sequence breaking. Attempting to use elements out of order triggers camera shake feedback.

---

### 🛠️ Technologies Used

- **Unity 2022.3**
- **Zenject** — Dependency Injection
- **New Input System**
- **DOTween** — Animations
- **Unity Timeline + Cinemachine** — Cinematic sequence
- **TextMeshPro**
- **NUnit** — Unit testing
- **ScriptableObjects** — Data-driven design

---

### 📁 Project Structure

```bash
Assets/_Projects/Scripts/
├── Core/           # Cockpit elements, managers, player systems
├── Data/           # All ScriptableObject definitions
├── Infrastructure/ # Zenject installers and registries
├── Interfaces/     # IInteractable, IToggleableElement, etc.
└── Editor/         # Custom inspectors
```

---

### 🚀 Installation

**Option 1: Clone from GitHub**
```bash
git clone https://github.com/xvostik201/TheChecklist.git
```
**Option 2: Download .rar**

Download: [TheChecklist_v1.0-takeoff-demo.rar](https://github.com/xvostik201/TheChecklist/releases/tag/v0.1-takeoff-demo)
Extract and open .exe

How to run:

Open the project in Unity
Load the main scene: Assets/_Projects/Scenes/MainScene.unity
Press Play

No additional setup required.

---

<div align="center">

📜 **License** — MIT  
📮 **Contact** — [zkostyutkin2004@gmail.com](mailto:zkostyutkin2004@gmail.com)  
📮 **LinkedIn** — [Contact me =) ](https://www.linkedin.com/in/zakhar-kostyutkin-b2740b393/)

👤 **Author** — Zakhar Kostyuktin (xvostik201)  

**Made with passion for flight simulation and clean code.**

</div>
