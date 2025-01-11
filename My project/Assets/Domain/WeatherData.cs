
namespace Domain
{
    [System.Serializable]
    public class WeatherData
    {
        public Properties properties;
    }

    [System.Serializable]
    public class Properties
    {
        public Period[] periods;
    }

    [System.Serializable]
    public class Period
    {
        public string name;
        public string startTime;
        public string endTime;
        public int temperature;
        public string temperatureUnit;
        public string windSpeed;
        public string windDirection;
        public string shortForecast;
        public string icon;
    }
}