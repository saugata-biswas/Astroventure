### Game Design Document

Date: 22.06.2021  
Name of the Game: Astroventure  
Name of the Student: Saugata Biswas  
Tutorial: 1  
Link to game repository: [https://github.com/saugata-biswas/Astroventure.git](https://github.com/saugata-biswas/Astroventure.git)

Table of content
1. [Overview](#overview)
	1. [Game abstract](#game-abstract)  
	1. [Objectives to be achieved by the game](#objectives-to-be-achieved-by-the-game)
	1. [Core gameplay](#core-gameplay)
	1. [Game features](#game-features)
		1. [Genre](#genre)
		1. [Number of players](#number-of-players)
		1. [Game theme](#game-theme)
		1. [Story summary](#story-summary)
1. [Mechanics](#mechanics)
	1. [Game elements categories](#game-elements-categories)
	1. [Rules](#rules)
		1. [Interaction rules](#interaction-rules)
		1. [Artificial intelligence](#artificial-intelligence)
	1. [Game world elements](#game-world-elements)
	1. [Game log elements](#game-log-elements)
	1. [Other elements](#other-elements)
	1. [Assets list](#assets-list)
1. [Dynamics](#dynamics)
	1. [Game world](#game-world)
		1. [Game world theme details](#game-world-theme-details)
		1. [Missions/levels/chapters flow](#mission/levels/chapters-flow)
	1. [Missions/levels/chapters elements](#mission/levels/chapters-elements)
		1. [Objectives](#objectives)
		1. [Rewards](#rewards)
		1. [Challenges](#challenges)
	1. [Special areas](#special-areas)
	1. [Game interface](#game-interface)
	1. [Controls interface](#control-interface)
	1. [Game balance](#game-balance)
1. [Visuals and sounds](#visuals-and-sounds)
	1. [Game visuals](#game-visuals)
	2. [Game sounds](#game-sounds)
1. [Document information](#document-information)
	1. [Definition, acronyms and abbreviations](#definition-acronyms-and-abbreviations)
	1. [Document references](#document-references)
1. [Attachments](#attachments)

## Overview 
Astroventure is a role playing game(RPG) where the main objective is to complete a rescue mission. There will be two main Non-Player Characters(NPC) in the game. The roles of these NPCs are not predefined. Their behavior to the player will be determined by the game state. These NPCs have their own objective: to gain most control of the resources compared to the other one. The player has to outwit the NPCs to make his way. This is the main feature of the game. Currently, Astroventure is intended for PC, e.g., Windows or Linux.

## Game abstract
Astroventure takes place in a huge spaceship. The player character is an astronaut who lands at this spaceship. His main objective is to capture a mystery item from the ship's cargo. The spaceship is a self-sustaining one. It has two artificially intelligent agents. These AI NPCs are controlling the spaceship. Each of the NPCs control some sentinels/bots. These bots will help/hinder the player depending on the NPCs controlling them. The player is an unwanted guest, hence, he has to outwit or subjugate the NPCs to reach his goal. The game will have multiple levels(at least 3/4). When the player will enter these levels, he will have limited resources with him. He will need to fight/convince the NPCs to let him through the level.    

## Objectives to be achieved by the game
In Astroventure, the player has to defeat, negociate, subjugate or convince the AI NPCs to gain resources, which the player will use access to the mystery box. Basically, it will try to mimic a balance in the three main characters: the player and the two NPCs. Most of the time, when the player becomes friend to one NPC, the other will become his enemy. This is the core dynamic that the game would approach. 

## Core gameplay
In each level, the NPCs controls some sentinels/bots. These bots only listen or respond to its master NPC. The NPCs also hold control of other game resources, e.g. weapons, oxygen, food etc. The player needs to gain access to these resources to finish the level. The sentinels/bots usually will oppose the player. The player has to utilize on the fact that the NPCs also oppose each other. The player has to fight or negotiate to make friend with atleast one of the NPCs which will make the other NPC his enemy. A friendly NPC will grant access to the resources. On the contrary, an unfriendly NPC will hinder the player. This will lead to conflict in the game. 

## Game features
The game would not have a clear distinction between friendly and enemy NPCs. The player has to find out how he/she will develop the relationship with the NPCs to progress through the game.

## Genre
Astroventure is a RPG with rescue as its main objective. However, it is also an action game as the player has to fight with the sentinels/bots to make his way. 

## Number of players
Currently, Astroventure is intended to be a single player game.

## Game theme
The game will take place in a futuristic spaceship. The spaceship has a lot of chambers. Each level will happen in a chamber. Currently, only three to four levels will be developed.  

## Story summary
A strange big shaceship as a mysterious cargo. This item needs to be inspected. The player character is assigned to inspect and collect the item. However, the spaceship environment is unknown to the player. The player character docks his space vehicle to the spaceship to gain entry. The game starts here.

## Mechanics
The spaceship is rotated on its own axis, hence, it has a artificial gravitational pull. Hence, every object which has a mass will affected by gravity. The NPC will have cannot be shot/destroyed by the weapons found on the spaceship. They are immnue to weapons since they are merely holographic representatons. 


## Game elements categories
|Category name| Description|
|---|---|
|Player character| This will be a single player charater.|
|Krittim(NPC0)|This NPC controls some sentinels/bots|
|Mittha(NPC1)|This NPC will have similar characteristics as the NPC0|
|sentinels/bots| These sentinels/bots control will be specific to a game level|

## Rules
When the player enters the level, the NPCs are suspicious of the player and regard him as emeny. The player fights the sentinels/bots sent by the NPCs. 

## Interaction rules
|Interaction rule|results|
|---|---|
|Dialogue using emojis|This will be to used to either accept or reject a proposal. Emojis will also be used to show mental states of NPCs|
|Guns|Upon firing guns on the sentinels/bots thosse would be destroyed. NPCs cannot be destroyed|
|Axe|Upon using some doors can be broken|
|Balls|Can be rolled to disperse sentinels/bots|

## Artificial intelligence
A probabilistic graphical model or decision tree will be used to determine which of the NPCs behaves how, e.g. as friend or foe.

## Game world elements
Game world is a spaceship. A limited map of it can be accessed by the player. Sometimes the player can use some floating device to go up in a level|

## Game log elements
Health, oxygen, enemys killed/neutralized etc. will be logged.

## Other elements
There could be some isolated NPCs which aren't controlled by the two main AI NPCs.

## Assets list
|Asset|Description|
|---|---|
|Player character| main character that the player can control|
|Krittim(NPC0) and Mittha(NPC1)|Floating holograms|
|sentinels/bots|The gameobjects that fights with the player or assists him|
|Guns|Used to kill the sentinels/bots|
|Oxygen cylinder|Used to sustain player character's life|
|Electro-magnetic pulse(EMP) gun|Special gun that can disrupt the AI NPCs prior belief/attitudes|

## Dynamics
Yet to be decided.

## Game world
The game takes place on a spaceship, named Synaptron, with artificial gravity. Upon using the EMP gun, the ship's electrical equipments can malfunction. The gravitational pull can disappear temporarily.

## Game world theme details
Game world is a futuristic spaceship. It would have an industrial interior. 

## Missions/levels/chapters flow
There will be 3/4 levels in the game. Levels would have increasing difficulty. More choice of weapons will be available as the game progresses. Higher level can have betrayal by the friedly NPCs. Hence, the player has to be more careful in a higer level. 

## Missions/levels/chapters elements
Core gameplay will be formed mainly by the temporal contract among the player and the AI NPCs.

## Objectives
- The player has to reach to the mystery item to be inspected or rescued.
- The player has to finish each levels to reach to the mystery object.
- The player has to make friends with atleast one AI NPC to progress through the level.

## Rewards
- When a the player make friend/subjugate an AI NPC, it assists the player by giving up some weapons or fighting the other AI NPC.

## Challenges
- Fight through the sentinels/bots
- Manipulate the AI NPCs to gain resources
- Use EMP gun when necessary

## Special areas
- There are no special areas planned currently.

## Game interface
The player can mainly manipulate the inventory.

## Controls interface
The game will be seen from 3rd person perspective. The player needs to control the camera view to see most of the environment. An assisted camera might be available during gameplay.

## Game balance
Game difficulty can be adjusted initially. It would increase/decrease the game uncertainty in the AI NPCs' belief system.

## Visuals and sounds
Visuals sounds design is yet to be decided.

## Game visuals
At first, freely available assets from asset store will be used for the player character, NPCs, sentinels/bots. Some of the visuals can be updated later. Animations has been added from mixamo.com; a humanoid character named Dreyar has been added. Idle, walking, and running animation has been added.

## Game sounds
Curretly, only freely available sounds/music will be used.

## Document information
Document information will be constantly updated.

## Document-acronyms-and-abbreviations
|Abbreviation, acronym|Full form|
|---|---|
|NPC|Non-Player Character|
|RPG|Role Playing Game|
|AI|Artificial Intelligence|

## Document references
Following references are followed to make the game.

Time. Unity Learn. https://learn.unity.com/tutorial/time-0fbw?projectId=5df2611eedbc2a0020d90217&amp;tab=overview&amp;uv=2019.4.

Pluggable AI. Unity Learn https://learn.unity.com/tutorial/pluggable-ai-with-scriptable-objects#5c7f8528edbc2a002053b487

Code Monkey - Scnene Manager in Unity https://unitycodemonkey.com/video.php?v=3I5d2rUJ0pE

Mixamo https://www.mixamo.com/

Unity's animation system  https://www.youtube.com/playlist?list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO

## Attachments
Currently, there are no attachments.


















