using DG.Tweening;
using UnityEngine;

namespace View.UI
{
    public class LoadingIndicator : MonoBehaviour
    {
        [SerializeField] private RectTransform spinner;
        [SerializeField] private float rotationSpeed = 1f;

        private void OnEnable()
        {
            spinner.DORotate(new Vector3(0, 0, -360), rotationSpeed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
        }

        private void OnDisable()
        {
            spinner.DOKill();
        }
    }
}