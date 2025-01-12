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
            }
            else
            {
                Debug.LogError("<color=green>WeatherController innited</color>");
            }
            if (WeatherController == null)
            { 
                Debug.LogError("WeatherController not found in scene");
            }
        }
        public WeatherController WeatherController;

    }
}