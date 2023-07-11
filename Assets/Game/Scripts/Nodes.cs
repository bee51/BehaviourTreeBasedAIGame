using System.Collections.Generic;


namespace Game.Scripts
{
    public enum NodeStatus
    {
        Success,
        Running,
        Failure,
    }

    public class Node
    {
        public NodeStatus status;
        public List<Node> childrenList = new List<Node>();
        public string name;
        public int currentChildIndex=0;

        public Node(string name)
        {
            this.name = name;
        }

        public void AddChild(Node addedNode)
        {
            childrenList.Add(addedNode);
        }

       
    }
}