using UnityEngine;


namespace Domain
{
    public class FactsListClass : StateBase
    {
        public override void Enter(StateMachine statemachine)
        {
            Debug.Log("FactsListClass Enter");
        }

        public override void Execute(StateMachine statemachine)
        {
            Debug.Log("FactsListClass Execute");
        }

        public override void Exit(StateMachine statemachine)
        {
            Debug.Log("FactsListClass Exit");
        }
    }
}