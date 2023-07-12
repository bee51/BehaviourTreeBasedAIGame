using System.Collections.Generic;

namespace Game.Scripts
{
    public class PSelector : Node
    {
        public Node[] nodeArray;
        public bool isOrdered;

        public PSelector(string name) : base(name)
        {
            base.name = name + "PSelector";
        }

        public void OrderNodes()
        {
            nodeArray = childrenList.ToArray();
            Sort(nodeArray, 0, childrenList.Count - 1);
            childrenList = new List<Node>(nodeArray);
        }

        //QuickSort
        //Adapted from: https://exceptionnotfound.net/quick-sort-csharp-the-sorting-algorithm-family-reunion/
        public int Partition(Node[] array, int low,
            int high)
        {
            Node pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j].sortOrder <= pivot.sortOrder)
                {
                    lowIndex++;

                    Node temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            Node temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        public void Sort(Node[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }


        public override NodeStatus Process()
        {
            if (!isOrdered)
            {
                isOrdered = true;
                OrderNodes();
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
                isOrdered = false;
                return childStatus;
            }

            currentChildIndex++;
            //   all children and failed
            if (currentChildIndex >= childrenList.Count)
            {
                currentChildIndex = 0;
                isOrdered = false;
                return NodeStatus.Failure;
            }


            //  running next children
            return childStatus;
        }
    }
}