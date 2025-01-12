using UnityEngine;

namespace Domain
{
    public class WeatherScreenState : StateBase
    {
        public override void Enter(StateMachine statemachine)
        {
            statemachine.contexData.WeatherController.StartWeatherUpdates();
            Debug.Log("WeatherScreenState Enter");
        }

        public override void Execute(StateMachine statemachine)
        {
            //Debug.Log("WeatherScreenState Execute");
        }

        public override void Exit(StateMachine statemachine)
        {
            statemachine.contexData.WeatherController.StopWeatherUpdates();
            Debug.Log("WeatherScreenState Exit");
        }
    }
}