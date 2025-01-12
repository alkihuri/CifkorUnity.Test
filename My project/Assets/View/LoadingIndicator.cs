using UnityEngine;

namespace View.UI
{
    public class LoadingIndicator : MonoBehaviour
    {
        [SerializeField] private RectTransform spinner;
        [SerializeField] private float rotationSpeed = 200f;

        private void Update()
        {
            if (spinner != null)
            {
                spinner.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
            }
        }
    }
} 