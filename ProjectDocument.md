# Game Basic Information #

## Summary ##

Space Evaders is a twist on the classic space invader games. In our version, the edge of the galaxy has been overrun by space droids and asteroids, and they are destroying whatever they can in the universe. As the spaceship’s pilot, you will be flying through a desolate space scene,  with only meteors and enemy droids for company. 

## Gameplay explanation ##

You move your character using W,A,S,D.
Fire your primary laser using Mouse1.
In the middle of the game, a blue orb power up will spawn. If you touch it, you will gain access to one Super Laser Charge.
Use your superlaser charge by pressing Mouse2.
Aim your superlaser by moving your mouse in the direction of the asteroids.
Survive till the end and win!




# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface - Mit Tank
### Main Menu
Our initial design of Space Evaders was close to that of Space Invaders, with its classic retro feel. The menu includes an arcade-y soundtrack, coupled with a sci-fi influenced font and a space-themed background. The buttons either direct the player to the game with “Play,” or exit the game with “Quit.” Each button gets highlighted when the mouse is over it. 

### Gameplay 
The game interface includes a ship moving through space, a scoreboard, and a health bar above it. The ships movement is indicated by the stars, asteroids, and enemy ships flying past it. As the ship navigates the area, any collisions with asteroids or enemy ships causes the health bar to shrink. Any asteroids or ships destroyed by the player (with his/her two different laser attacks) causes 10 points to be added to the scoreboard. Both the scoreboard and the health bar have their own respective controller scripts. 

### Pause (By Brian)
The escape button allows the player to pause the game, opening a menu of choices. The choices are displayed over a dimmed game, allowing the player to know the exact game state as it was paused. The player can then resume, go back to the menu, or exit the game by choosing one of the buttons. The PauseMenu script controls this. 
 
### Victory Screen (By James)
The victory screen is shown when the player gets to the end of the game without dying. It has the option to play again or quit the game. On this screen, a victory soundtrack is played.

### Game Over
As the player loses all of their lives, a game over screen is shown. A retro, melancholic  soundtrack, one that resembles those that are played towards the end of old games, is played with a space background and the words “GAME OVER,” displayed. 

## Movement/Physics - Eric Lee
### Movement
Movement happens in the x, y, and z axes. The y-axis goes in/out of the page and
game objects always appear to move forward on this axis (Asteroids and space
droids cannot move away from the spaceship). Horizontal and vertical movement is
in the x and z axes.

Movement for all game entities must be within boxed boundary regions that are
predefined inside the Unity editor. The spaceship has a smaller movement
boundary region than that of other game entities which ensures that it is always
possible for other game entities to collide with the spaceship and also provides
the feeling of a larger game space than what the screen shows.  
[Spawn Position Generation Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/LevelController.cs#L75-L90)

The spaceship only moves in the x and z axes, but it appears to move at a
constant speed in y-axis due to the background star animation. Spaceship
movement is not instantaneous -- a constant force is applied to the spaceship
which results in a constant acceleration. It also means that the acceleration is
dependent on the spaceships' mass. Upon hitting the spaceship boundary, the
spaceship stops moving. The spaceship is purposely allowed to be cut off
slightly by the screen so that it can fire at asteroids at the very edge of the
boundary.  
[Spaceship Movement Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/PlayerController.cs#L32-L40), [Spaceship Boundary Check Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/PlayerController.cs#L65-L84)

Asteroids move in the y-axis at a random speed, do not move in the x and z axes,
and rotate as they move. Asteroids ignore collisions with the boundaries.  
[Ignore Boundaries
Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/AsteroidController.cs#L18-L23)

Space Droids also move in the y-axis at a random speed, but are also spawned
with a random movement script that controls how they move in the x and z axes.
For all of these movement scripts, the movement direction reverses when it hits
the boundary, which ensures that the Space Droids will stay on the screen until
they pass by or are destroyed by the spaceship. Furthermore, the scripts
implement movement in the x and z axes that do not follow the physics system,
but instead uses direct translation to move the Space Droid. All other game
entities use the physics system to control movement. ( `DroidController`
[link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Controllers/DroidController.cs))

The seven movement scripts in Assets/Scripts/Movement are derived from a `MovementBase` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/MovementBase.cs)) abstract class:
1. `RandomMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/RandomMovement.cs))
   * Moves randomly in the x and z directions.
2. `CornerMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/CornerMovement.cs))
   * Targets the four corners of the spaceship boundary to discourage hiding in
    corner.
3. `HorizontalMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/HorizontalMovement.cs))
   * Moves left and right at a random speed.
4. `VerticalMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/VerticalMovement.cs))
   * Moves up and down at a random speed/
5. `SpiralMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/SpiralMovement.cs))
   * Moves in a circle of random radius at a random speed.
6. `ZigZagMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/ZigZagMovement.cs))
   * Moves in a zig-zag fashion at a random speed. The horizontal movement speed
     is different from the vertical movement speed.
7. `RandomBurstMovement.cs` ([link](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Movement/RandomBurstMovement.cs))
   * Moves randomly with periodic bursts of speed forward in the y direction.
     This is meant to be the most complex and difficult type of Space Droid to
     deal with since the time between bursts, the speed of the burst, and the
     length of the burst are all random. The x and z axis movements are also
     random which makes Space Droids with this movement script very difficult to
     predict. 

### Physics
Space Evaders leverages Unity's built-in physics system to control collisions
and movement. The game uses the standard physics model by attaching a Rigidbody
component to all spawned game objects. Collisions are handled within the
Controller classes and are automatically detected by Unity through colliders.
CapsuleColliders were used for the spaceship, asteroids, and space droids, while
BoxColliders were used for the boundaries. Asteroids and Space Droids use
discrete collision detection while the spaceship uses continuous collision
detection.

Some physics conventions for the game are:
1. No gravity or friction.
2. All non-boundary game entities must have a Rigidbody component.
3. All game entities are not kinematic.
4. Non-boundary game entities must collide with each other. They cannot overlap.
5. All non-spaceship game entities have a mass of 1, drag of 0, and angular drag
   of 0.
6. Game object movement must be handled by altering the `Rigidbody`
   * No altering the game object transform directly
7. Spaceship speed is controlled by changing the mass and drag
8. BoxColliders on the boundaries are always triggers.

Examples:
* [Space Droid y-axis movement](https://github.com/jameslu255/spaceshooter/blob/82f47964cea0a685854fe32fc68d80d9ea00261a/Assets/scripts/Controllers/DroidController.cs#L13)
* [Spaceship movement implementation](https://github.com/jameslu255/spaceshooter/blob/82f47964cea0a685854fe32fc68d80d9ea00261a/Assets/scripts/Controllers/PlayerController.cs#L38)
* [PlayerBoundary screenshot](Screenshots/movement-physics/PlayerBoundary.png)
* [SpawnBoundary screenshot](Screenshots/movement-physics/SpawnBoundary.png)
* [Space Droid screenshot](Screenshots/movement-physics/SpaceDroid.png)

## Animation and Visuals - Keaton Elliott
### Assets:
[Spaceship](https://assetstore.unity.com/packages/3d/vehicles/space/free-sf-fighter-11711)

[Asteroids](https://assetstore.unity.com/packages/3d/environments/asteroids-pack-84988)

[Explosions](https://assetstore.unity.com/packages/vfx/particles/fire-explosions/fire-spell-effects-36825)

[Scene Transition](https://assetstore.unity.com/packages/tools/particles-effects/simple-fade-scene-transition-system-81753)

[Space Droids](https://assetstore.unity.com/packages/3d/vehicles/space/space-droid-32200)

### Beam Firing Animation
Because this game is supposed to be based on the classic space invaders arcade game, all visuals should be a similar feel, but more modern looking. We accomplished this using some simple additions to assets from the Unity asset store. The main firing mechanic of the ship is made more futuristic than the initial simple projectile from the original space invaders by changing into a beam weapon. The animation for this beam came with the asset when downloaded, but it fits in well with the rest of the scene. The secondary firing system uses the same asset, prolongs it and allows it to be aimed.

### Movement Simulation
Another animation that adds to the effect of flying through space is the random particle generation in the background to simulate passing by stars, galaxies, and anything else in space. Because the ship itself is not actually moving in the different it seems it should be, this particle system creates that sense that you are progressing through space, and actually moving. Also, the speed and randomness of the particles gives the movement a similar feel to moving through hyperspace. A very similar particle system is attached to the back of the spaceship asset, adding to the movement illusion and giving the ship itself a more lifelike appearance. This system uses one of the flame assets to give it the correct color and interaction with the environment. 

### Player Visuals/Animations
The ship itself is a complicated asset that we downloaded from the store. It has different aspects that you can activate and deactivate, including the boosters that come off the sides. This ship fits in with the general atmosphere of the game as it is a similar style to classic space invader games, if they were rendered in 3D space.

### Collision Consequences
Managing collisions between the invaders (in this case asteroids and space droids) and the ship itself needs to have the same weight to it as the classic game. For this reason, on every collision an explosion prefab is instantiated with a sound queue as well. As described in the game feel section, collisions with the player itself should have more weight to them, so we added a screen shake as well. To further emphasize this, the sound effect of this collision is a different, heavier impact than a shot collision. The explosion is another asset we got from the store itself, and it fits the feel of the game as it is very similar to many classic explosions in the sci fi genre.

### Transitioning Between Scenes
To make transitions between the start menu, gameplay, and game over menu more smooth, we used a simple scene transition asset from the store. This made it less jarring and more fluid when the player began playing the game, and helped the game over screen not appear so abrupt. It also helps the player actually understand that their health is fully depleted, by allowing them to see their player explode before transitioning to the end scene.

## Input - Brian Nguyen

**Describe the default input configuration.**


**Keyboard**

We decided to follow classic input configuration for flash games by keeping controls very simple. Input for ship movement is handled by `GetAxis()` which takes in horizontal and vertical axes  in [PlayerController.cs](https://github.com/jameslu255/spaceshooter/blob/master/Assets/scripts/Controllers/PlayerController.cs), and is defaulted to WASD and arrow keys in Unity. We intend to have the primary keys as WASD, however the arrow keys can also be used for movement as well. WASD are the primary keys for movement to allow for easy access to the Pause Menu by clicking Escape. `GetButtonDown()` was used to retrieve user input for Escape. We wanted gamers to have easy access to the pause button in case they have to suddenly pause.  

**Mouse Clicks**

Mouse clicks are used to select buttons from the Start and Pause menus. Pause menu buttons were handled by attaching methods from [PauseMenu.cs](https://github.com/jameslu255/spaceshooter/blob/master/Assets/PauseMenu.cs) to the buttons’ `onClick()` event. The alpha levels of the menu items were edited so that buttons become darker when the mouse hovers over them and gets even darker when a button is selected. This was implemented to make navigation easier and to make the buttons appear more responsive. We hoped to improve game feel by reaffirming gamer’s intent to choosing a button.  The size of buttons was also stressed and greatly depends on the importance of buttons. The Resume button in the pause menu is larger than the Menu and Quit buttons so gamers can easily navigate back to the action of the game. Left-click/Alt is utilized to fire a regular beam and right click is utilized for the special beam. Despite Space being a classic key for firing projectiles in games, we opted to go with left-click since we have a right-click for the special beam and wanted to keep things uniform. Input for the beams are handled in [MultiShooter.cs](https://github.com/jameslu255/spaceshooter/blob/master/Assets/BasicBeamShot/Script/MultiShooter.cs) using `GetButtonDown()` with `Fire1` and `Fire2` as arguments. 


**Mouse Movement**

Mouse movement is another form of input within Space Evaders. When firing the special beam with right-click, gamers are able to use their mouse to control the beam direction. This was implemented in [MultiShooter.cs](https://github.com/jameslu255/spaceshooter/blob/master/Assets/BasicBeamShot/Script/MultiShooter.cs). Gamers can wiggle their mouse left and right in order to create a wavy beam for extra destruction. Initially, the special beam just had a slightly longer duration than the regular beam, but we chose to make the special beam direction controllable by the mouse to add more juice to the game. We made the special beam controllable in hopes of adding satisfaction to the game through the capability to destroy multiple asteroids and droids with a single beam.


**Add an entry for each platform or input style your project supports.**

Currently, our game is only supported by keyboard controls and mouse. However, we hope to add PS4/Xbox controller support in a future release. 

## Game Logic - James Lu

### Scenes
Currently the game has states either “Playing” mode or “Screen Mode”. Playing mode is when the game is officially loaded and you have to pilot your ship to survive. These are managed using `UnityEngine.SceneManagement` and using `SceneManager` to change the scenes that we are currently on. `SceneManager` is called within many functions such as `MainMenuController.cs` (which controls what the Main menu, Victory Screen, and End Screen does). It is also found within the `LevelController.cs` because we need to transition to the victory screen when the game is over.

### Waves
I decided for the game to have a linear play through with only a set number of waves. This is because by having a limited number of waves we can create additional levels later rather than making the game endless. However, the more waves you complete, the game will get more challenging. On wave 4 we start adding Droids that move around erratically. On wave 8 we start increasing the number of enemies. Our final wave is technically easier than wave 8 and this was a design choice because the music we are playing in the background starts to decrease in intensity, thus we decrease the intensity of the game as well.

### Firing Delay
I also decided to have a limit on the firing of Mouse1. Originally, the player could spam the fire and have almost no challenge. A delay using Timers was implemented in order to make the player make careful decisions when to fire their laser. I also made it so that the laser will always one-shot the enemy. This makes it more rewarding because not only is there a long delay, but if you use it properly, you will 100% annihilate your foe.

### Power Ups
I decided to have a power up system to enhance your player. This was done by creating an instance of a “powerUp” prefab that will move along with the enemies. Once the player comes in contact with the prefab, it will destroy the prefab and add a charge to the “laserPowerUp” in the MultiShooter.cs script. This script controls how the player input is determined so it makes sense to keep track of the number of superlaser charges here. If the super laser charges are 0, then you cannot use your Mouse2.

### Values that are kept track of
Values that we have to keep track of throughout the game is in GameController. We have to keep track of how many laserPowerUps we have, keep track of whether or not the player is currently firing their laser so that other moves should be disabled. We also have to keep track of the score in the gamecontroller.


# Sub-Roles

## Audio - Mit Tank
[Start Screen Music](https://www.youtube.com/watch?v=Bok8nLviThg&list=PLobY7vO0pgVKn4FRDgwXk5FUSiGS8_jA8&index=9)

[Explosion Sound Effect](https://www.audioblocks.com/royalty-free-audio/sound-effects/explosion)

[Laser Sound Effect](https://www.zapsplat.com/sound-effect-category/lasers-and-weapons/)

[Super Laser Sound Effect](https://www.zapsplat.com/sound-effect-category/lasers-and-weapons/)

[Game Over Music](https://www.youtube.com/watch?v=br3OzOrARh4)

[Victory Screen Music](https://www.youtube.com/watch?v=vX1xq4Ud2z8&list=PLobY7vO0pgVKn4FRDgwXk5FUSiGS8_jA8&index=1)

### Main Menu
A simple, retro soundtrack is played as the main menu is loaded. The `PlaySoundOnStart.cs` script starts the audio clips as the scene “Start” is loaded.

### Gameplay
The main background music is loaded within the `GameController.cs` as the scene is loaded in. It features an adventurous type of soundtrack fit to go with the space theme. Any time the player collides with an asteroid/enemy ship, the OnTriggerEnter() function within the `PlayerController.cs` plays an explosion sound. Both the primary laser and the secondary laser each have separate sounds called within the `AudioScript.cs` and the `AudioScript2ndary.cs`.

### Victory Screen
When the player finishes the game through without dying, a victory screen is displayed with several options and an upbeat, retro soundtrack in the background. The `PlaySoundOnStart` script is used here.

### Game Over
A retro, 8-bit type of soundtrack is played when the “End” scene is loaded. Here again, the `PlaySoundOnStart` script is used to call the sound clip.


## Gameplay Testing - James Lu

I tested 10 people. I tested people while the game was still incomplete so that I could gauge what else needed to be added to the game. 
Link to tests: https://docs.google.com/document/d/1bLgjpzBqRAew4YXp0Nd_95yhk4PBUHUfbX_L67Xw-to/edit?usp=sharing

From the early results, we learned that we need to have an ending to the game because some testers did not like how the game dragged on forever. There was no sense of accomplishment when the game will eventually lead to them losing. This was fixed by adding in Gameover and Victory screens and loading them using `SceneManager`.

Some other tests told us that the player controls were stiff. This was because our early designs of the game made the player’s ship take time to move and thus made the game feel like the player was lagging. We fixed this by making the ship move almost instantaneously and also adding ship rotations when the player strafes to the left or right.

Other testers told us that the input controls were weird because the primary laser was tied to spacebar while it needed to be aimed with the mouse. To fix this, we made the laser move in a straight line and then changed the input to Mouse1. 

Yet another tester complained about how our loading screens had no music. I decided to add music to the Start and End Screens. This was done using an Audio Source and linking an audio clip and having the Audio Source play music using `AudioSource.Play()`.

### Other things I added when testing on my own:
* I decided to add the power ups system when testing the game mid production. 
* I also added sound effects to when power-ups were collected
* I also changed the color of the model of the player when a powerup is collected so that it is easier to identify. This was done by setting the “MeshRenderer” to blue. It was set to “White” (which means clear all colors) when the powerup was used.
* I also added Screen shaking because when the player was hit by a meteor or enemy, the player took damage but the player took it like a rock and didn’t move. The shake makes it seem more impactful.
* I felt that the background of the game was pretty drab. I decided to add some planet models in the background to make the game have more life to it.
* I also added a “Danger” sound when the player got low health so that it is easier for the player to detect that they are in danger.


## Narrative Design - Keaton Elliott
### Current
The basic premise of our game is very similar to the classic space invaders with a twist. In our version, space has been overrun by space droids and they are destroying whatever they can in the universe. This is demonstrated by the desolate scene you are flying through, with only meteors and enemy robots for company. You are a pilot who was caught up in the mess around him/her.
Your mission in this game is to survive the waves of enemies and natural obstacles to get to the end. Doing this proves your ability to navigate hostile territory, while removing as many problems for potential future pilots as possible. 
These space droids have already destroyed much of space around you, so you must traverse through what is left as quickly and efficiently as possible to return to the relative safety of your destination.

### Future/DLC
In a later version of the game, the start and end will be more clearly defined. You will not just be navigating through wave after wave of enemies, you will also have a more defined purpose - to carry a payload, which might be a message, supplies, people, or any number of other things from one place to another. Your ship is one of the last ways for distant worlds to communicate with each other in their fight back against the seemingly infinite space droids. This will be demonstrated by having a clear takeoff point, from a planet or space station asset, and a clear end when you have cleared a set number of waves of obstacles. 
This future release will also make more use of the score system - higher score turns into currency you can use when you reach an objective. While navigating between objectives, you are paid for taking out as many enemies and obstacles as possible, to make the journey easier for other pilots. Your ship needs to be repaired at every stop, and that costs some of the accumulated score, while the rest can be spent upgrading.

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

Link to the trailer:
 https://youtu.be/xR4AZfiPW2U
 
Link to presskit: https://docs.google.com/document/d/1nx5TypxdYf_mZV7XWv0_s0P7XtWeQYH1o4V3uzhATsc/edit

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

When creating my trailer, I had a few key points I wanted to accomplish. I wanted to start off the trailer by briefly explaining the story behind the game and how the main protagonists (the spacecraft and the crew on board) got to where they were. I also wanted to include gameplay footage to give the audience a taste of the game. To conclude my trailer, I wanted to end with a call to action to get the audience excited about the game.  

Screenshots were chosen in order to give the best overview of the gameplay. I wanted to give viewers a glimpse of the capabilities of the spaceship’s firepower as well as damage that can occur from enemy droids or asteroids.

## Game Feel - Eric Lee
### Ship Movement
I followed a tip from the "Why Does Celeste Feel So Good to Play? | Game Maker's
Toolkit" video and tried to make the spaceship fun to move around even when
there were no asteroids or other obstacles. To do this, I adjusted the mass and
drag values of the spaceship as well as the amount of applied force.
Additionally, I played around with the spaceship's ADSR envelope. As a heavy
spaceship carrying and delivering a payload, I wanted it to not feel super
snappy, but still be responsive enough to dodge hazards. With that in mind, I
chose to use an AR envelope instead of an ADSR envelope:

1. Medium acceleration and no speed cap.  
   This kind of attack curve allows the spaceship to move across the screen
   quickly and smoothly. Tapping the movement keys barely moves the ship, which
   forces the player to react early to avoid obstacles. The lack of speed cap
   helps the ship get across the screen as quickly as possible and makes the
   game feel more responsive and enjoyable to play. The `AddForce()` method is
   used to apply the acceleration. Furthermore, I chose to use the `Impulse`
   Force Mode parameter since it made the ship feel a lot snappier and gives the
   player a greater sense of control over the ship.
2. Very large deceleration (Short release)  
   I gave the ship a very large drag,which causes it to stop very quickly. This
   helps the game feel a more fun and responsive since the spaceship can change
   directions more quickly and also prevents the spaceship from drifiting into
   obstacles. To avoid making the stop not feel jerky, I implemented ship
   rotation so that the ship would appear to still be moving even when it has
   already stopped moving position wise.

### Collision Leniency
I also adjusted the colliders to not match the prefab shape very closely. In the
Juice lesson, the creators of Celeste mentioned that the game should match
player intent instead of forcing the player to hit the button at the exact
correct frame / time. Similarly, I adjusted the Collider sizes on the
Rigidbodies so that the edges of the spaceship will not collide with obstacles.
I also made the asteroid and space Droid Colliders a bit larger so that they're
easier to shoot since the 3D graphics can make aiming difficult. The beam shot
parameters were set so that they behaved less like bullets, but more like long
energy rays that stop at the first obstacle hit. The beam stays on the screen
for a short while and anything that runs into it will also get destroyed. This
makes the shooting feel a bit more satisfying since the aiming does not need to
be as precise.  
[Spaceship Collider](Screenshots/movement-physics/Spaceship.png)

### Randomness
From the Juice It or Lose it video, I followed the tips and added randomness to
most of the asteroid and space droid parameters. This helps make the game feel
a bit different each time without actually changing the code. 

### Screen Shake (By James) and Particle Effects (by Keaton)
James implemented screen shake on collision which not only gives a second alert
to the player apart from the explosion animation but also gives the player the
idea that the ship has actually taken damage. As mentioned in the Juice it or
Lose it video, it makes the collision seem more dangerous and important. Keaton
implemented the particle effects at the back of the spaceship, which adds to the
experience when moving the spaceship around the screen.

