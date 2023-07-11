using System.Collections.Generic;

namespace Game.Scripts
{
    public class BehaviourTree : Node
    {
        public BehaviourTree(string name) : base(name)
        {
            // json or xml file writing references
            base.name = name + "tree";
        }

        public void PrintTree()
        {
            string treePrintOut = "";
            Stack<Node> nodeStack = new Stack<Node>();
            Node currentNode = this;
            nodeStack.Push(currentNode);
            while (nodeStack.Count != 0)
            {
                Node nextNode = nodeStack.Pop();
                treePrintOut += nextNode.name + "\n";
                for (int i = nextNode.childrenList.Count; i >= 0; i--)
                {
                    nodeStack.Push(nextNode.childrenList[i]);
                }
            }
        }
    }
}