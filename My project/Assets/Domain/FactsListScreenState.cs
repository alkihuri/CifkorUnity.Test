using UnityEngine;


namespace Domain
{
    public class FactsListScreenState : StateBase
    {
        public override void Enter(StateMachine statemachine)
        {
            statemachine.contexData.FactsListController.LoadFacts();
            Debug.Log("FactsListScreenState Enter");
        }

        public override void Execute(StateMachine statemachine)
        {
            // Debug.Log("FactsListClass Execute");
        }

        public override void Exit(StateMachine statemachine)
        {
            statemachine.contexData.FactsListController.CancelCurrentRequest();
            Debug.Log("FactsListScreenState Exit");
        }
    }
}