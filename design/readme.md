class: center, middle

## Artificial Intelligence

# Designing Game AI

<br>

Gerard Escudero, 2020

<br>

![:scale 40%](figures/legoduplo.jpg)

.footnote[[source](https://schoolbox.wordpress.com/tag/lego-duplo/) ]

---
class: left, middle, inverse

# Outline

* .cyan[The Design]

* Game Genres

* AI-Based Game Genres

* References

---

# Design of Game AI

- .blue[Behaviors] required

- .blue[Technologies] to achieve them

![:scale 75%](figures/esquema.png)

---

# Evaluating the Behaviors I

.blue[Movement]:

- How realistic does the physics have to be?

- Will agents need to work out where to go?

- Will agent's motion need to be influencced by other agents?

- Will chasing/avoiding be enough? Or moving in formations?


.blue[Decision Making]:

- What is the full range of actions agents have?

- Will agents look ahead to select best decision?

- Will it need to change decisions depending on player acts?

- Will it need memory? Using some kind of learning?

---

# Evaluating the Behaviors II

.blue[Tactical & Strategy]:

- Do your agents need to work together?

- Do they need to carry out sequences depending on time?

- Do they need tactical or strategic information to select the appropiate behavior?

- Do you need some decisons to be made for a group of agents at a time?

## Selecting Techniques

Most of the AI needs will raise from the answer to these questions.

- Do we some pathfinding of tactic component?

- Which decision making technique fits better?

---
class: left, middle, inverse

# Outline

* .brown[The Design]

* .cyan[Game Genres]

* AI-Based Game Genres

* References

---

# Shooters I

.blue[Movement]: 
  - Control of the enemies
  - Sophisticated Movement & Animations components
  - Pathfinding?

.blue[Firing]: 
  - Accurate fire control
  - Allow agents to miss?

.blue[Decision Making]: 
  - FSMs or BTs
  - Randomness
  - *F.E.A.R.*: GOAP systems

---

# Shooters II

.blue[Perception]: determining who to shoot and where they are
  - *radius* of action
  - *messages* between agents?
  - *Cone of sight*?
  - *radius* of sound?

.blue[Tactical AI]?
 - Tactical Waypoints
 - Pathfinding layer

---

# Shooter-like Games I

*First- or third-person viewpoint with human like agents.*

.blue[Platform and Adventure Games]

- Younger audience than shooters.

- Agents interesting, but predictable. <br>Enemies like puzzles (exploit its weaknesses).

- Similar AI techniques but simpler.

.blue[Melee Combat]

- Similar to shooters.

- Timing is fundamental<br>Attacks in phases: *Windup*, *Interruptible*, *Invulnerable*, *Cooldown*

- AI has to include time<br> what to execute and when

---

# Shooter-like Games II

.blue[MMOGS]

*Massively multi-player online games*

- Separation between server and player machines.

- It requires a critical mass of players.

  - Marginal need of AI. Most of the players humans.

  - Most add some AI challenge.

- AI (scalable).

  - Pathfinding.

  - Sensory Perception.

---

# Driving

*How well the AI drives a car?*

.blue[Movement]

- *Crucial task*.

1. Racing lines for optimal speed (designer).
  - Predefined path (spline: curve).
  - Steerings for returning to the path.
  - *Formula 1* (1996)
  - *Grand Theft Auto 3* (2001) (background cars)
2. Physics simulation.
  - Cars tries to follow racing lines in the same conditions as the player.
  - *Overtaking* by second racing lines.
  - *Chase the rabbit* (ghost)
  - Neural Networks: *Forza Motosport* (2005)
  - Next generation will come by Deep Learning.

---

# No Fixed Tracks

.blue[Pathfinding and Tactical AI]

- *Driver* (1999): new genre, city streets.
  - Catch or avoid other cars.

- Cars generated on surrounding blocks of player position.

- Pathfinding to find routes for catching the player.

- Tactical to find escape routes and block them.

- Police cars tactical pathfinding without crossing player's path.


.blue[Driving Like Games]

- Some sport games use racing technologies: <br>
*SSX* (2000), *Steep* (2016).

---

# Real-Time Strategy I

- *Dune II* (1992)

- PC Platform

.blue[Pathfinding]

- Long Pathfinding problems (speed is crucial).

- Grid-based structured (very large).

- Pre-computed route data in some games.

- Changing navigation graph: *Starcraft II* (2010), *Company of Heroes* (2006)

.blue[Group Movement]

- Formation movement

- Dynamic surrounding level: *Full Spectrum Warrior* (2004)

---

# Real-Time Strategy II

.blue[Tactical and Strategic AI]

- Inluence maps:

  - Guide pathfinding and strategic decisions.

  - Selection o construction locations.

  - Influence maps + spatial reasoning for wall construction <br> *Empire Earth* (2001).

.blue[Decision Making]

- Rule-based system.

- Information from tactical analysis engine.

---

# Sports

- Strategy from professionals who play the game (to be encoded).

- Players expect to see human-level competence.

- Team sports: agents reacts to the situation of the rest of the team.

.blue[AI levels]:

- Strategic decisions (sometimes action learning).

- Coordinated motion of the team: formation motion.

- Individual behavior.

.blue[Physics Prediction]

- Intercepting ball, projectile prediction...

- Pool or golf is complex and basic part of the game.

.blue[Playbooks]: set of movement patterns.

---
class: left, middle, inverse

# Outline

* .brown[The Design]

* .brown[Game Genres]

* .cyan[AI-Based Game Genres]

* References

---

# Teaching Characters I

*Creatures* (1996), *Black & White* (2001).

- Observational learning based in positive or negative feedback.

.blue[Representing Actions]: as facts
```
Action(fight, enemy, sword)
Action(throw, rock)
Action(throw, enemy, rock)
Action(sleep)
```
.blue[Representing the World]

- Association of the context with the actions: <br>
Eating food is good, but not when being attacked.

- Representation as: set of parameters or facts.

---

# Teaching Characters II

.blue[Learning Mechanism]

- Naïve Bayes, Decision Trees, Neural Networks...

- *Strong supervision*: from observations.
- *Weak supervision*: from player.

- *Input*: context. 
- *Output*: action.

- Speed of learning vs speed of forgetting: <br>
Related with the training with many iterations in a NN.

---

# Teaching Characters III

.blue[Predictable Mental Models]

- When learning from player feedback: <br>
Which part of a specific actions is being judged?

- *Instincts*: occasional behavior (independent or not of the learning process).

- *The brain death*: combinations of learning that leaves an agent incapable.
  
---

# Flocking and Herding Games I

*Herdy Gerdy* (2002), *Pikmin* (2001), *Pikmin 2* (2004).

.blue[Creatures]:

- Simple decision making: FSM or DT.

- Steerings: graze, flee, flocking.

.blue[Steerings]:

- *Interactivity*: reaction of the player to group movement! <br>
Increase *cohesion*.

-  Watch out for the *stability* in group movement.<br>
"Chain reaction" in movement.

---

# Flocking and Herding Games II

.blue[Ecosystem Design Rules]:

- *Size of the Food Chain*
  - *Primary creature*: those of the player. 
  - Recommended two level above and one below.

- *Behavior Complexity*
  - Predator complexity related game difficulty.
  - Higher creatures in food chain should not work in groups.

- *Sensory Limits*
  - Fixing a perception radius helps player predictions.

- *Movement Range*
  - Primary creatures must move in a limited range when they are not interacting with the user


---
class: left, middle, inverse

# Outline

* .brown[The Design]

* .brown[Game Genres]

* .brown[AI-Based Game Genres]

* .cyan[References]

---

# References

- Ian Millington. _AI for Games_ (3rd edition). CRC Press, 2019.


