using System;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Scripts
{
    public class ExampleBehaviour : MonoBehaviour
    {
        public enum ActionState
        {
            Idle,Working,Failure
        }
        public ActionState state;
        private NodeStatus _treeStatus;
        private NavMeshAgent _agent;
        
        [SerializeField] private Transform aimPoint;
        [SerializeField] private Transform startPoint;
        
        
        // 
        private BehaviourTree _tree;
        private void Start()
        {

            _tree = new BehaviourTree("RobberTree");
            Sequence steal = new Sequence("Steal");
            Leaf goToObject = new Leaf("GoObject",GoObject);
            Leaf goBack = new Leaf("GoBack",GoBack);
            
            _tree.AddChild(steal);
            
            // it is add sequence items
            steal.AddChild(goToObject);
            steal.AddChild(goBack);
            
            
            _tree.PrintTree();
        }

        private void LateUpdate()
        {
            if (_treeStatus != NodeStatus.Running)
            {
                _treeStatus = _tree.Process();
            }
        }

        public NodeStatus GoToLocation(Vector3 destination)
        {
            float distanceToTarget = Vector3.Distance(transform.position, destination);
            if (state == ActionState.Idle)
            {
                state = ActionState.Working;
            }
            else if (Vector3.Distance(_agent.pathEndPosition,destination) >=2)
            {
                state = ActionState.Idle;
                return NodeStatus.Failure;

            }
            else if (distanceToTarget<2)
            {
                state = ActionState.Idle;
                return NodeStatus.Success;
            }

            return NodeStatus.Running;
        }
        public NodeStatus GoObject()
        {
            return GoToLocation(aimPoint.position);
        }

        public NodeStatus GoBack()
        {
            return GoToLocation(startPoint.position);
        }
        
        

    }
}