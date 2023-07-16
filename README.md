# Behavior Trees for AI Characters in Unity

This repository contains behavior tree elements for AI characters in Unity using C#. Behavior trees are a popular approach for implementing AI in games and other interactive systems. They provide a hierarchical structure for organizing AI logic, making it easier to design and maintain complex AI behaviors.

## What is a Behavior Tree?

A behavior tree is a directed acyclic graph (DAG) where each node represents an atomic behavior or a higher-level composite behavior. It is composed of three main types of nodes:

1. **Action Nodes**: These nodes represent atomic actions that an AI character can perform. Examples include "MoveToPosition", "AttackEnemy", or "PatrolArea". Action nodes can directly interact with the game environment or modify the character's internal state.

2. **Conditional Nodes**: These nodes represent conditions that determine whether an action should be executed. Examples include "IsPlayerInSight", "IsHealthLow", or "IsEnemyInRange". Conditional nodes evaluate certain conditions and return a true or false value.

3. **Composite Nodes**: These nodes represent higher-level behaviors composed of other nodes. There are different types of composite nodes, including:

    - **Sequence**: Executes child nodes in order until one fails or all succeed.
    - **Selector**: Executes child nodes in order until one succeeds or all fail.
    - **DepSequence**: Executes all child nodes simultaneously, returning success or failure based on a specified policy.
    - **Decorator**: Modifies the behavior of a single child node by altering its return value or execution flow.

Behavior trees are typically evaluated from the root node down to the leaf nodes, considering the outcome of each node to determine the next node to execute. This evaluation process creates a dynamic decision-making system that can adapt to changing conditions.


## Leaf Actions

Leaf actions are the lowest-level actions in a behavior tree and are typically represented as action nodes. These actions directly affect the AI character's behavior and can include a wide range of activities, such as:

- **Movement**: Move to a specific position, follow a path, or navigate around obstacles.
- **Interaction**: Interact with objects, pick up items, or open doors.
- **Combat**: Attack enemies, use special abilities, or defend against incoming attacks.
- **Decision Making**: Make strategic decisions based on the current game state.
- **Animation**: Play specific animations or trigger visual effects.
- **Communication**: Communicate with other characters or relay information.

  
## Repository Structure

This repository provides a set of behavior tree elements that you can use as a foundation for implementing AI characters in Unity. It includes the following files:

- `BehaviorTree.cs`: Contains the main behavior tree class that manages the evaluation and execution of the tree.
- `ActionNode.cs`: Defines the base class for action nodes.
- `ConditionalNode.cs`: Defines the base class for conditional nodes.
- `SequenceNode.cs`: Implements the sequence composite node.
- `SelectorNode.cs`: Implements the selector composite node.
- `DepSequence.cs`: Implements the parallel composite node.
- `DecoratorNode.cs`: Implements the decorator composite node.

Feel free to extend or modify these classes to suit your specific requirements. Additionally, you can create new behavior tree elements by inheriting from the provided base classes.

## Usage

To use the behavior tree elements in your Unity project, follow these steps:

1. Clone or download this repository to your local machine.
2. Copy the relevant behavior tree files into your Unity project's assets folder.
3. Attach the `BehaviorTree` component to your AI character game object.
4. Configure the behavior tree by adding the appropriate nodes and setting their parameters.
5. Call the `Update()` method of the `BehaviorTree` component to evaluate and execute the tree.

Make sure to refer to the Unity documentation for more information on how to work with Unity and C#.



## Acknowledgments

Special thanks to the open-source community for their contributions and inspiration in the field of behavior trees and AI in general.

If you have any questions, suggestions, or bug reports, feel free to open an issue or submit a pull request. Enjoy using behavior trees for your AI characters in Unity!
