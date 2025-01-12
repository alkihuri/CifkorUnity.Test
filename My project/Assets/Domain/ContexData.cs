using Controllers;
using UnityEngine;



namespace Domain
{
    public class ContexData
    {
        public ContexData()
        {
            if (WeatherController == null)
            {
                WeatherController = GameObject.FindObjectOfType<WeatherController>();
                if (WeatherController == null)
                {
                    Debug.LogError("WeatherController not found in scene");
                }
            }
            else
            {
                Debug.LogError("<color=green>WeatherController innited</color>");
            }
            if (WeatherController == null)
            {
                Debug.LogError("WeatherController not found in scene");
            }

            if (FactsListController == null)
            {
                FactsListController = GameObject.FindObjectOfType<FactsListController>();
                if (FactsListController == null)
                {
                    Debug.LogError("FactsListController not found in scene");
                }
            }
            else
            {
                Debug.LogError("<color=green>FactsListController innited</color>");
            }
              

        }
        public WeatherController WeatherController;
        public FactsListController FactsListController; 
    }
}