using DG.Tweening;
using UnityEngine;

namespace TestTaskManeraiInc
{
    public abstract class PunchBaseAnimation : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0f, 1f)] protected float punchPower = 0.2f;
        [SerializeField, Range(0f, 1f)] protected float punchDuration = 0.2f;
        
        protected Tween _tween;

        private void OnDisable()
        {
            StopTween();
        }
		
        protected void StopTween()
        {
            if (_tween != null && _tween.IsActive())
            {
                _tween.Kill();
            }
        }
    }
}
