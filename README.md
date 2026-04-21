# WarehouseRobotSim

A hybrid-language Warehouse Management System (WMS) simulation built with **.NET 10** and **Python 3**.

## Overview
This project simulates a warehouse environment where autonomous robots fulfill various orders. The system uses a modular architecture:
- **.NET Orchestrator:** Manages system state, simulation loops, and real-time APIs.
- **Python Intelligence:** Handles high-performance pathfinding (BFS/A*) and optimization logic.

## Architecture
The project demonstrates **Inter-Process Communication (IPC)** between C# and Python. Data is exchanged via JSON streams, allowing the backend to outsource complex algorithmic work to specialized Python scripts.

## Tech Stack
- **Backend:** ASP.NET Core (Razor Pages)
- **Algorithms:** Python (Standard Library / JSON IPC)
- **Frontend:** HTML5 Canvas / CSS Grid (In Progress)

## Current Status
- [x] Base project foundation and directory structure.
- [x] Core domain models (Grid, Robot, Order).
- [x] Functional C# to Python Bridge (Handshake verified).
- [ ] Simulation Orchestration Engine (Current Focus).
- [ ] Visual Dashboard.

## Setup
1. Clone the repo.
2. Ensure **Python 3** is installed and added to your system PATH.
3. Run the .NET project via Visual Studio or `dotnet run`.
