# Project Design Document: ShipKeeper
  - **Created at**: 03/01/2024
  - **Author**: Luis Arturo Guerra García

## Project Concept

[WORK IN PROGRESS]

### Summary

The player takes control of the main character, the ShipKeeper. A shipkeeper is a worker that lives in an abandoned dock, and gives service to ghostships, to repair them and clean them from "pests". These pests, however, are eldritch organisms that have taken the ship as their home while the ship was drifting at deep sea. Since these organisms cannot be left to live inland, you have been assigned with the mission of eliminating all pests properly.

For these purpose, a shipkeeper is provided with basic weapons/tools. However, if they prove to be efficient, they will found a way to improve their equipment.

Aside from a place to live and basic equipment, the Goverment of Wichdum Island does not provide with anything else. It is the responsability of the shipkeeper to provision themselves for survival.

### 1. Player Control

#### Table of Symbols

| Symbol | Meaning |
|------------|------------------|
|[A-Z]|Key letter, multiple letters are divided by commas (,)|
|[MBL]|Mouse Button Left click|
|[MBR]|Mouse Button Right click|

You control a **ShipKeeper** in this **TOP DOWN** game where:

| User Input | Makes the player |
|------------|------------------|
|[W,A,S,D]| walk in the direction of the pressed keys|
|[MBL]| Axe Attack|
|[MBR]| Shotgun Aim|
|[MBR] + [MBL]| Shotgun Shot|

### 2. Basic Gameplay

During the game:

| Object type | Action type | Condition |
|-------------|-------------|------|
|Blob|Grows towards the player|When close to the blob's area|
|Blob|Attacks the player| when the player touches the blob|
|Blob|Dies|when player destroys the blob's core|
|Blob|Drops "Eldritch meat"| When a part of it gets destroyed|
|Eldritch Meat|Get collected|When near the player|
|Gold Coin|Gets collected|When near player|
|Chest|Drops Swarm or Gold Coins| When openned by player|
|Swarm Unit|Moves arround the player|When dropped by a chest|
|Swarm Unit|Attack the player shooting acid|After a random time|
|Repair Wood|Get repaired by the player|When player executes action holding hammer|
|Repair Systems|Get repaired by the player|When player executes action holding soldering tools|

#### Game Goal

1. Clean the ship from all monsters
1. Repair all main damage to ship
1. Do not starve
1. Collect valuables from ship
1. Update Tools

### 3. Sounds & Effects

| Sound | Played when |
|-------|-------------|
|Example: DirtStepSound|when player walks on ground|

| Particle Effect | Played when |
|-----------------|-------------|
|Example: DirtParticle|when player walks on ground|

| Animation | Played when |
|-----------|-------------|
|Example: WalkAnimation|when player walks on ground|

### 4. Gameplay Mechanics

Gameplay posibilities: 
 
1. Hunger increases over time
1. Working shifts
1. Cooking/Crafting

As the game progresses:

| Description of gameplay mechanic | Effect on the game |
|----------------------------------|--------------------|
|Example: Everytime a minute pass|the enemy counter will increase 1 for the enemy spawner


### 5. User Interface

| Interface element | Action | On Condition |
|-------------------|--------|--------------|
|Example: Score|Increase|when player destroys an enemy|
|Example: Score|Decrease|when player destroys a package|

At the start of the game, the title **[WORKING TITLE]** will appear and the game will end when **[CONDITION TO END THE GAME]**.

### 6. Other Features

**[ANY OTHER NOTES ABOUT THE PROJECT THAT YOU DON'T FEEL WERE ADDRESSED IN THE ABOVE.]**

## Project Timeline

| Milestone | Due date | Description |
|-----------|----------|-------------|
| #1 | mm/dd | Player movement - Done|
| #2 | mm/dd | Player look - Done|
| #3 | mm/dd | Player attack - Done|
| #4 | mm/dd | Basic Ship Map - Done|
| #5 | mm/dd | Blob function - Done|
| #6 | mm/dd | Damage System - Done|
| #7 | mm/dd | Repair Ship System |
| #8 | mm/dd | Dropables |
| #9 | mm/dd | Inventory |
| #10 | mm/dd | Eat System |

## Future Ideas for monsters and encounters
| Monster | Description |
|-----------|----------|
|Planted Head| A human head whose neck is rooted to the floor. Will sleep on candle light. Other lights wake them up and attack the player|
|Crying Ghost| A passive ghost which keeps crying while staying in a specific place. It dissapears and appears in other random place if is seen by the player character directly for 2 seconds. Will only be released with a ritual. While they are in a room, the room will slowly get damaged.|
|Fishrats| Common pest, easy too kill, but usually make nests which keeps producing the fishrats. They are an amalgam of fish head and rat body.|
|Octocrab| An octorpus-like creature using a crab shell as defense.|
|Watermites|Watermites rot the wood of the ship, they can nest anywhere and if released, they will slowly damage the room. If left alive, after a while they will infect other rooms.|
|Meat lumps| Lumps of human flesh mashed together. Crawl slowly but somehow sturdy to kill. Chopping them is best way to kill them for good.|
|Sea spider| Little white spider that creates resistant webs. They usually don't attack the player but their webs can cause trouble. If Watermites reach a room with Sea Spiders, the sea spiders will eat the watermites, but this will make them grow and will be able to attack the player in their new form|

### Backlog

| Feature/Task | Due date |
|--------------|----------|
| Feature on backlog #1 - not a part of the minimum viable product | mm/dd |
| Feature on backlog #2 - not a part of the minimum viable product | mm/dd |
| Feature on backlog #3 - not a part of the minimum viable product | mm/dd |