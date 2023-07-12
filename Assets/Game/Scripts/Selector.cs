namespace Game.Scripts
{
    public class Selector : Node
    {
        public Selector(string name) : base(name)
        {
            base.name = name + "Selector";
        }

      

        public override NodeStatus Process()
        {
            NodeStatus childStatus = childrenList[currentChildIndex].Process();

            //running
            if (childStatus == NodeStatus.Running)
            {
                return childStatus;
            }

            //  success one child and finished
            if (childStatus == NodeStatus.Success)
            {
                currentChildIndex = 0;
                return childStatus;
            }

            currentChildIndex++;
            //   all children and failed
            if (currentChildIndex >= childrenList.Count)
            {
                currentChildIndex = 0;

                return NodeStatus.Failure;
            }


            //  running next children
            return childStatus;
        }
    }
}