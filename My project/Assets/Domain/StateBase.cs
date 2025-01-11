
namespace Domain
{
    public abstract class StateBase
    {
        public abstract void Enter(StateMachine statemachine);
        public abstract void Execute(StateMachine statemachine);
        public abstract void Exit(StateMachine statemachine);
    }
}