using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Domain.Data;
using TMPro;

namespace Controllers
{
    public class FactsListController : MonoBehaviour
    {
        private const string FactsApiUrl = "https://api.thedogapi.com/v1/breeds";
        private const string FactDetailsApiUrl = "https://api.thedogapi.com/v1/breeds/{0}";

        [SerializeField] private Transform factsListContainer;
        [SerializeField] private GameObject factItemPrefab;
        [SerializeField] private GameObject loadingIndicator;
        [SerializeField] private GameObject popup;
        [SerializeField] private TextMeshProUGUI popupTitle;
        [SerializeField] private TextMeshProUGUI popupDescription;

        private Coroutine currentRequest;


        public void LoadFacts()
        {
            if (currentRequest != null)
            {
                StopCoroutine(currentRequest);
            }

            currentRequest = StartCoroutine(FetchFacts());
        }

        public void CancelCurrentRequest()
        {
            if (currentRequest != null)
            {
                StopCoroutine(currentRequest);
                currentRequest = null;
            }

            loadingIndicator.SetActive(false);
        }

        private IEnumerator FetchFacts()
        {
            loadingIndicator.SetActive(true);

            using (UnityWebRequest request = UnityWebRequest.Get(FactsApiUrl))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    ProcessFactsResponse(request.downloadHandler.text);
                }
                else
                {
                    Debug.LogError($"Error fetching facts: {request.error}");
                }
            }

            loadingIndicator.SetActive(false);
        }

        private void ProcessFactsResponse(string jsonResponse)
        {
            Breed[] breeds = JsonHelper.FromJsonArray<Breed>(jsonResponse);

            if (breeds != null && breeds.Length > 0)
            {
                // Отображаем только первые 10 фактов
                for (int i = 0; i < Mathf.Min(breeds.Length, 10); i++)
                {
                    Breed breed = breeds[i];
                    CreateFactItem(i + 1, breed.name, breed.id);
                }
            }
        }

        private void CreateFactItem(int index, string name, int id)
        {
            GameObject item = Instantiate(factItemPrefab, factsListContainer);
            TextMeshProUGUI itemText = item.GetComponentInChildren<TextMeshProUGUI>();
            itemText.text = $"{index} - {name}";

            Button button = item.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => LoadFactDetails(id));
        }

        public void LoadFactDetails(int id)
        {
            if (currentRequest != null)
            {
                StopCoroutine(currentRequest);
            }

            currentRequest = StartCoroutine(FetchFactDetails(id));
        }

        private IEnumerator FetchFactDetails(int id)
        {
            loadingIndicator.SetActive(true);

            string url = string.Format(FactDetailsApiUrl, id);
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    ProcessFactDetailsResponse(request.downloadHandler.text);
                }
                else
                {
                    Debug.LogError($"Error fetching fact details: {request.error}");
                }
            }

            loadingIndicator.SetActive(false);
        }

        private void ProcessFactDetailsResponse(string jsonResponse)
        {
            BreedDetail breedDetail = JsonUtility.FromJson<BreedDetail>(jsonResponse);

            if (breedDetail != null)
            {
                ShowPopup(breedDetail.name, breedDetail.description);
            }
        }

        private void ShowPopup(string title, string description)
        {
            popup.SetActive(true);
            popupTitle.text = title;
            popupDescription.text = description;
        }

        public void ClosePopup()
        {
            popup.SetActive(false);
        }
    }
}
