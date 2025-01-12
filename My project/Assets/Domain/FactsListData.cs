// Вспомогательные классы для работы с API
using UnityEngine;

namespace Domain.Data
{

	[System.Serializable]
	public class Breed
	{
		public int id;
		public string name;
	}

	[System.Serializable]
	public class BreedDetail
	{
		public string name;
		public string description;
	}

	public static class JsonHelper
	{
		public static string WrapArray(string json)
		{
			return $"{{\"array\": {json}}}";
		}

		public static T[] FromJson<T>(string json)
		{
			return JsonUtility.FromJson<Wrapper<T>>(json).array;
		}

		[System.Serializable]
		private class Wrapper<T>
		{
			public T[] array;
		}
	}
}