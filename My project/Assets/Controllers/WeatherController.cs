using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Domain.Data;
using UnityEngine.UI;
using TMPro;

namespace Controllers
{
    public class WeatherController : MonoBehaviour
    {
        private const string WeatherApiUrl = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
        private Coroutine updateWeatherCoroutine;

        [SerializeField] private TextMeshProUGUI weatherText;
        [SerializeField] private Image weatherIcon;

        public void StartWeatherUpdates()
        {
            if (updateWeatherCoroutine == null)
            {
                updateWeatherCoroutine = StartCoroutine(UpdateWeatherPeriodically());
            }
        }

        public void StopWeatherUpdates()
        {
            if (updateWeatherCoroutine != null)
            {
                StopCoroutine(updateWeatherCoroutine);
                updateWeatherCoroutine = null;
            }
        }

        private IEnumerator UpdateWeatherPeriodically()
        {
            while (true)
            {
                yield return FetchWeather();
                yield return new WaitForSeconds(5f);
            }
        }

        private IEnumerator FetchWeather()
        {
            using (UnityWebRequest request = UnityWebRequest.Get(WeatherApiUrl))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    ProcessWeatherResponse(request.downloadHandler.text);
                }
                else
                {
                    Debug.LogError($"Error fetching weather: {request.error}");
                }
            }
        }

        private void ProcessWeatherResponse(string jsonResponse)
        {
            WeatherResponse weatherData = JsonUtility.FromJson<WeatherResponse>(jsonResponse);

            if (weatherData != null && weatherData.properties != null && weatherData.properties.periods.Length > 0)
            {
                var todayWeather = weatherData.properties.periods[0];
                UpdateWeatherUI(todayWeather.shortForecast, todayWeather.temperature);
            }
        }

        private void UpdateWeatherUI(string forecast, int temperature)
        {
            weatherText.text = $"{forecast} - {temperature}F";
            weatherIcon.sprite = GetWeatherIcon(forecast); // Логика для получения иконки
        }

        private Sprite GetWeatherIcon(string forecast)
        {
            // Здесь добавьте свою логику для сопоставления иконки прогнозу
            return null;
        }
    }


}
