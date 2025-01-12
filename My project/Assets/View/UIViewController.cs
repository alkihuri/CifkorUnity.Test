using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace View.UI
{

    public class UIViewController : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private float threshold = 0.5f;

        private enum ScrollState
        {
            Display1,
            Display2
        }

        private ScrollState currentState;

        private void Update()
        {
            float scrollPosition = scrollRect.horizontalNormalizedPosition;
            if (scrollPosition < threshold)
            {
                SwitchState(ScrollState.Display1);
            }
            else
            {
                SwitchState(ScrollState.Display2);
            }
        }

        private void SwitchState(ScrollState newState)
        {
            if (currentState != newState)
            {
                currentState = newState;
                OnStateChanged(newState);
            }
        }

        private void OnStateChanged(ScrollState state)
        {
            switch (state)
            {
                case ScrollState.Display1:
                    Domain.StateMachine.Instance.WeatherScreenScene();
                    Debug.Log("Switched to Display 1");
                    // Ваши действия для первого дисплея
                    break;
                case ScrollState.Display2:
                    Domain.StateMachine.Instance.FactsListScreen();
                    Debug.Log("Switched to Display 2");
                    // Ваши действия для второго дисплея
                    break;
            }
        }
    }
}
