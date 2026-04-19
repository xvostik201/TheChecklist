<div align="center">

# 🛰️ The Checklist
### Advanced Cockpit Interaction Framework

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Unity](https://img.shields.io/badge/Unity-2022.3-black?logo=unity)
![Zenject](https://img.shields.io/badge/DI-Zenject-green?logo=unity)
![DOTween](https://img.shields.io/badge/Animation-DOTween-red?logo=unity)

---

A high-fidelity modular framework for complex cockpit interactions in Unity. Designed for aerospace and tactical simulations, this system emphasizes **Clean Architecture**, **Dependency Injection**, and a data-driven approach to physical controls.

### 🎥 Preview

![MainGif](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/MainGif0.gif)

</div>

### ✈️ Overview

This framework demonstrates:
* **Decoupled Architecture:** Complete separation of concerns using **Zenject** (Input Management → Interaction Logic → Camera Controller → Cockpit Elements).
* **Event-Driven Workflow:** Systems communicate via C# Actions/Events, eliminating hard dependencies and `Find()` calls.
* **Data-Driven Physics:** Mechanical limits, sensitivity, and interaction types are defined via **ScriptableObjects**.
* **Immersive Feedback:** A unique "Interaction Resistance" system that dynamically adjusts camera fluidity when operating heavy mechanical levers.

---

<div align="center">

### 📸 Architecture & Prototyping

| Component Mapping | Checklist Debug Output |
| :---: | :---: |
| ![MainImage](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/MainImage.png) | ![ChecklistDebugLog](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/ChecklistDebugLog.png) |
| *Whitebox-prototype of control elements* | *Real-time validation via ChecklistManager* |

| Button Configuration | Dragging Configuration | Lever Configuration | Checklist Configuration |
| :---: | :---: | :---: | :---: |
| ![ButtonData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Button.png) | ![DragData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Drag.png) | ![LeverData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Lever.png) | ![ChecklistData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/ChecklistStepSO.png) |
| *Click-based interaction* | *Precision physical dragging* | *Binary state toggling* | *SO-driven sequences* |

</div>

---

### 🛠️ Key Features

**🎯 Mission & Checklist System**
* **State-Driven Progression:** Automatically monitors cockpit element states and triggers the next objective only when requirements are met.
* **Interface-Agnostic Validation:** Uses `IToggleable` and `INormalizedElement` to validate both binary (On/Off) and continuous (0.0-1.0) control values.
* **Safe Initialization:** Implements a deferred initialization pattern to ensure all scene elements are registered in the global registry before the mission starts.

**🎯 Interaction Engine**
* **Normalized Data Output:** Translates physical rotation into a standardized `0.0f - 1.0f` range.
* **Memoization Pattern:** Caches `IInteractable` references in a `Dictionary` to maintain **144+ FPS** with zero GC allocations.
* **Smart Viewport Raycasting:** Centralized interaction point calibrated for FPS-style cockpit views.

### ✅ Quality Assurance & Testing
The framework includes **Unit Tests** (NUnit) to verify mathematical precision:
* **Validation:** Verified calculation of normalized values (0.0 - 1.0) regardless of mechanical rotation clamps.
* **Regression Testing:** Automated suite to prevent logic breaking during physics or data-structure refactoring.

<div align="center">
  
![TestRunner](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/NormalizedTest.png)

</div>

---

### 🗺️ Roadmap

- [x] **Core Interaction Engine** (Buttons, Levers, Dragging).
- [x] **Dependency Injection** (Zenject integration).
- [x] **Mission Framework** (Checklist system).
- [ ] **Visual Fidelity Upgrade:** Replacing whitebox prototypes with high-fidelity PBR-textured 3D models.
- [ ] **Full Cockpit Implementation:** Recreating a functional cockpit of a specific aircraft.
- [ ] **Interactive Tutorial/Credits:** A dedicated scene showcasing the development process and contributors.

---

### 🎮 Controls

| Action | Input |
| :--- | :--- |
| **Interact** | Left Mouse Button |
| **Aim / Look** | Mouse Movement |

<br>

<div align="center">

📜 **License** Licensed under the **MIT License**.

📮 **Contact** 📧 [zkostyutkin2004@gmail.com](mailto:zkostyutkin2004@gmail.com) | 🧩 [LinkedIn Profile](https://www.linkedin.com/in/zakhar-kostyutkin-b2740b393/)

**xvostik201 by Zakhar Kostyuktin**

</div>
