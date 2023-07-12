namespace Game.Scripts
{
    public class Inverter: Node
    {
        public Inverter(string name) : base(name)
        {
            base.name=name + "Inverter";
        }

        public override NodeStatus Process()
        {
            NodeStatus childStatus = childrenList[currentChildIndex].status;
            if (childStatus == NodeStatus.Running)
            {
                return childStatus;
            }

            else if (childStatus == NodeStatus.Failure)
            {
                return NodeStatus.Success;
            }

            return NodeStatus.Success;
        }
    }
}