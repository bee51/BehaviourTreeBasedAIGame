namespace Game.Scripts
{
    public class DependencySequence : Sequence
    {
        public BehaviourTree dependancy;
     
        public DependencySequence(string name) : base(name)
        {
            this.name=name + "Dependency sequence";
        }
  

        public DependencySequence(string name,BehaviourTree tree) : base(name)
        {
            dependancy=tree;
            this.name = name;
        }

        public override NodeStatus Process()
        {
            if (dependancy.Process() ==  NodeStatus.Failure)) {
                ;
                // Reset all children
                foreach (Node n in childrenList) {

                    n.Reset();
                }
                return status = NodeStatus.Failure;
            }

            return base.Process();
        }

     
    }
}