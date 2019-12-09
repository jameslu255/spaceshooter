# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**




# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

## Movement/Physics - Eric Lee
### Movement
Since Space Evaders is a 3D game, movement happens in the x, y, and z axes. The
y-axis goes in/out of the page and game objects must appear to move forward on
this axis (Asteroids and space droids cannot move away from the spaceship).
Horizontal and vertical movement is in the x and z axes respectively.

Movement for all game entities must be within boxed boundary regions that are
predefined inside the Unity editor. The spaceship must have a smaller movement
boundary region than that of other game entities. This ensures that it is always
possible for other game entities to collide with the spaceship and also provides
the feeling of a larger game space than what the screen shows.  
[Spawn Position Generation Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/LevelController.cs#L75-L90)

The spaceship only moves in the x and z axes, but it appears to move at a
constant speed in y-axis due to the background star animation. Spaceship
movement is not instanteous -- a constant force is added to the spaceship which
results in a constant acceleration. It also means that the acceleration is
dependent on the spaceships' mass. Upon hitting the spaceship boundary, the
spaceship stops moving. The spaceship is purposely allowed to be cut off
slightly by the screen so that it can fire at asteroids at the very edge of the
boundary.  
[Spaceship Movement Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/PlayerController.cs#L32-L40), [Spaceship Boundary Check Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/PlayerController.cs#L65-L84)

Asteroids move in the y-axis at a random speed and do not move in the x and z
axes. They also rotate as they move. Asteroids ignore collisions with the
boundaries. [Ignore Boundaries Method](https://github.com/jameslu255/spaceshooter/blob/45a5b6a434f77417f42de14c3975bb7242047063/Assets/scripts/Controllers/AsteroidController.cs#L18-L23)

Space Droids are similar to the asteroids because they also move in the y-axis
at a random speed. However, Space Droids are spawned with a random movement
script that controls how they move in the x and z axes. For all of these
movement scripts, the direction of the movement reverses when it hits the
boundary. This means that Space Droids will stay on the screen until they pass
by or are destroyed by the spaceship. Furthermore, the scripts implement
movement in the x and z axes that do not follow the physics system, but instead
uses direct translation to move the Space Droid. All other game entities use the
physics system to control movement. ( `DroidController`
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
and movement. The game does use the standard physics model. Collisions are
handled within the Controller classes and are automatically detected by Unity.
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
* [PlayerBoundary screenshot](/Screenshots/movement-physics/PlayerBoundary.png)
* [SpawnBoundary screenshot](/Screenshots/movement-physics/SpawnBoundary.png)
* [Space Droid screenshot](/Screenshots/movement-physics/SpaceDroid.png)

## Animation and Visuals

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

We decided to follow classic input configuration for flash games by keeping controls very simple. The primary keys for movement are WASD, however the arrow keys can also be used for movement. Space is utilized to fire a regular beam and right click is utilized for the special beam. The escape key is used to pause the game and launch the pause menu.

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel - Eric Lee
### Ship Movement
I adjusted the mass and drag values of the spaceship's Rigidbody as well as the
amount of force applied to make moving the spaceship feel better. I tried to
follow a tip from the "Why Does Celeste Feel So Good to Play? | Game Maker's
Toolkit" video and make the spaceship fun and nice to move around even when
there are no asteroids or other obstacles. Furthermore, I played around with the
spaceship's ADSR envelope. As a heavy spaceship carrying and delivering a
payload, it should not feel super snappy, but it should be responsive enough to
dodge hazards as they come. The game does this by having an AR envelope instead
of an ADSR envelope:

1. Medium acceleration and no speed cap
   This allows the ship to move across the screen quickly, but it doesn't allow
   the ship to make rapid movements to dodge. The acceleration forces the player
   to react early to avoid obstacles. The lack of speed cap helps the ship get
   across the screen as quickly as possible and makes the game feel more
   responsive and enjoyable to play. This is controlled through the `AddForce()`
   method.
2. Very large deceleration (Short release)
   I gave the ship a very large drag,which causes it to stop very quickly. This
   helps the game feel a more fun and responsive since the spaceship can change
   directions more quickly and also prevents the spaceship from drifiting into
   obstacles. To avoid making the stop not feel jerky, I implemented ship
   rotation on turns so that the ship would appear to still be moving even when
   it has already stopped moving in the XZ coordinate plane.

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

