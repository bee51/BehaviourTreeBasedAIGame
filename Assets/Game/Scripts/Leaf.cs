using UnityEngine;

namespace Game.Scripts
{
    public class Leaf : Node
    {
        public delegate NodeStatus Tick();

        public Tick ProcessMethod;

        public Leaf(string name, NodeStatus pm) : base(name)
        {
            // json or xml file writing references
            base.name = name + "tree";
            ProcessMethod += pm;
        }

        public override NodeStatus Process()
        {
            if (ProcessMethod != null)
            {
                return ProcessMethod();
            }

            return NodeStatus.Failure;
        }
    }
}