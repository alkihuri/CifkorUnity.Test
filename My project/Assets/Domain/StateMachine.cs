using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Domain
{
    public class StateMachine : MonoSinglethon<StateMachine>
    {
        private WeatherScreenState weatherScreenState;
        private FactsListClass factsListClass;
        private StateBase currentState;

        public ContexData contexData;



        private void Start()
        {
            contexData = new ContexData();
            weatherScreenState = new WeatherScreenState();
            factsListClass = new FactsListClass();
            currentState = weatherScreenState;
            currentState.Enter(this);
        }

        private void Update()
        {
            currentState.Execute(this);
        }

        public void ChangeState(StateBase newState)
        {
            currentState?.Exit(this);
            currentState = newState;
            currentState.Enter(this);

            Debug.Log("State changed to " + currentState.GetType().Name);
        }

        public void FactsListScreen()
        {
            ChangeState(factsListClass);
        }

        public void WeatherScreenScene()
        {
            ChangeState(weatherScreenState);
        }
    }
}