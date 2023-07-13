using UnityEngine;

namespace Game.Scripts
{
    public class Sequence : Node
    {
        public Sequence(string name) : base(name)
        {
            base.name = name + "sequence";
        }

        public override NodeStatus Process()
        {
            NodeStatus childStatus = childrenList[currentChildIndex].status;


            if (childStatus == NodeStatus.Running || childStatus == NodeStatus.Failure)
            {
                return childStatus;
            }

            currentChildIndex++;
            // finishing of sequence
            if (currentChildIndex >= childrenList.Count)
            {
                currentChildIndex = 0;
                return NodeStatus.Success;
            }

            // next step of sequence
            return NodeStatus.Running;
        }
    }
}