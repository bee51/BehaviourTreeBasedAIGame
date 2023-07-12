namespace Game.Scripts
{
    public class RandomSelector : Node
    {
        public Node[] nodeArray;
        public bool isRandomize;


        public RandomSelector(string name) : base(name)
        {
            base.name = name + "PSelector";
        }



        public override NodeStatus Process()
        {
            if (!isRandomize)
            {
                isRandomize = true;
                childrenList.Shuffle();
            }

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
                isRandomize = false;
                return childStatus;
            }

            currentChildIndex++;
            //   all children and failed
            if (currentChildIndex >= childrenList.Count)
            {
                currentChildIndex = 0;
                isRandomize = false;
                return NodeStatus.Failure;
            }


            //  running next children
            return childStatus;
        }
    }
}