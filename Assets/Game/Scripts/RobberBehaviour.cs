using System;
using UnityEngine;

namespace Game.Scripts
{
    public class RobberBehaviour : MonoBehaviour
    {
        private void Start()
        {

            BehaviourTree tree = new BehaviourTree("RobberTree");
            Node steal = new Node("Steal");
            Node goToObject = new Node("GoObject");
            Node goBack = new Node("GoBack");
            tree.AddChild(steal);
            steal.AddChild(goToObject);
            steal.AddChild(goBack);
            tree.PrintTree();
        }

    }
}