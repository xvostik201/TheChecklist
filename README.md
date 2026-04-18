# 🛰️ The Checklist (Advanced Cockpit Interaction Framework)

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Unity](https://img.shields.io/badge/Unity-2022.3-black?logo=unity)
![Zenject](https://img.shields.io/badge/DI-Zenject-green?logo=unity)
![DOTween](https://img.shields.io/badge/Animation-DOTween-red?logo=unity)

A high-fidelity modular framework for complex cockpit interactions in Unity. Designed for aerospace and tactical simulations, this system emphasizes **Clean Architecture**, **Dependency Injection**, and a data-driven approach to physical controls.

🎥 **Preview**

![MainGif](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/MainGif0.gif)

✈️ **Overview**

This framework demonstrates:
* **Decoupled Architecture:** Complete separation of concerns using **Zenject** (Input Management → Interaction Logic → Camera Controller → Cockpit Elements).
* **Event-Driven Workflow:** Systems communicate via C# Actions/Events, eliminating hard dependencies and `Find()` calls.
* **Data-Driven Physics:** Mechanical limits, sensitivity, and interaction types are defined via **ScriptableObjects**, allowing for instant balancing.
* **Immersive Feedback:** A unique "Interaction Resistance" system that dynamically adjusts camera fluidity when operating heavy mechanical levers.

📸 **Architecture & Prototyping**

| Component Mapping |
| :--- |
| ![MainImage](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/MainImage.png) |
| *Whitebox-prototype of control elements* |

| Button Configuration | Dragging Configuration | Lever Configuration |
| :--- | :--- | :--- |
| ![ButtonData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Button.png) | ![DragData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Drag.png) | ![LeverData](https://github.com/xvostik201/TheChecklist/raw/main/Assets/_Projects/Documentation/Lever.png) |
| *Click-based interaction* | *Precision physical dragging with ScriptableObject-defined rotation clamps* | *Binary state toggling* |

🛠️ **Key Features**

🎯 **Interaction Engine**
* **Normalized Data Output:** Levers and throttles translate physical rotation into a standardized `0.0f - 1.0f` range, ready for any checklist or flight-model logic.
* **Smart Viewport Raycasting:** Centralized interaction point calibrated for FPS-style cockpit views with customizable range and layer filtering.
* **Multi-State Support:** Unified base for **Buttons** (push), **Levers** (toggle), and **Thrust** controls (drag).

🎛️ **Architecture**
* **Dependency Injection:** Powered by **Zenject** to maintain a scalable, singleton-free codebase with dedicated installers for every subsystem.
* **Global Settings:** Centralized `GeneralData` ScriptableObject for managing mouse sensitivity, rotation clamps, and interaction resistance globally.

### ⚡ Optimization: Interface Caching
To maintain **144+ FPS** while handling dozens of interactive components, I implemented a **Memoization Pattern** for Raycast resolution:
* **Dictionary Lookup:** Instead of calling `GetComponent` during every interaction frame, the system caches `IInteractable` references in a `Dictionary<Collider, IInteractable>`.
* **Zero GC Allocations:** Interaction logic avoids frequent allocations, ensuring smooth camera movement even during complex mechanical operations.

### 🧠 Implementation Spotlight: Decoupled Camera Feedback

The following logic showcases how the **Interaction System** communicates with the **Camera Controller** without a direct reference. When a "Drag" starts, the camera receives a signal to increase "Resistance," simulating the physical effort and focus required to move a heavy lever.

```csharp
// 1. In PlayerInteractable.cs: Signal the start of a physical interaction
private void StartDragging(IInteractable interactable)
{
    _isDragging = true;
    _currentInteractable = interactable;
    
    // Broadcast event - subscribers like CameraRotation will react automatically
    OnInteractionStarted?.Invoke(); 
    _currentInteractable.OnInteract();
}

// 2. In CameraRotation.cs: Dynamic sensitivity adjustment based on interaction state
private void Rotate(Vector2 delta)
{
    // Fetch resistance from GeneralData SO: (e.g., 4.0f when locked, 1.0f when free)
    float resistance = _isLocked ? _settings.DraggingResistance : 1f;
    
    float mouseX = (delta.x * _settings.MouseSensitivity) / resistance;
    float mouseY = (delta.y * _settings.MouseSensitivity) / resistance;
    
    xRotation = Mathf.Clamp(xRotation + mouseY, -_settings.XRotationClamp, _settings.XRotationClamp);
    yRotation -= mouseX;
}
```

🎮 **Controls**

| Action | Input |
| :--- | :--- |
| **Interact** | Left Mouse Button |
| **Aim / Look** | Mouse Movement |

▶ **How to Build**

1. Unity **2022.3 LTS** or newer.
2. Clone repository.
3. Open the project and launch the main scene.

📜 **License**

This project is licensed under the **MIT License**.

📮 **Contact**

📧 Email: zkostyutkin2004@gmail.com
🧩 LinkedIn: [Click](https://www.linkedin.com/in/zakhar-kostyutkin-b2740b393/)]

📄 **Developer Note**

This project was created as a technical demonstration of clean software architecture and procedural animation systems in Unity, showcasing how SOLID principles can be applied to core gameplay mechanics.

---
**xvostik201 by Zakhar Kostyuktin**
