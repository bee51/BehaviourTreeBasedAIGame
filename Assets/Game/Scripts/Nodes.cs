using System.Collections.Generic;
using System.Diagnostics;


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
        public int sortOrder;

  
        // json or xml file writing references

        public Node(string name)
        {
            this.name = name;
        }
        public Node(string name, int order)
        {
            this.name = name;
            sortOrder = order;
        }

     

        public virtual NodeStatus Process()
        {
            return childrenList[currentChildIndex].status;
        }
        public void AddChild(Node addedNode)
        {
            childrenList.Add(addedNode);
        }

       
    }
}