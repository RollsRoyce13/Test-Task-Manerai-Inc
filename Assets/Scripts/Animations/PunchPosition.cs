using DG.Tweening;
using UnityEngine;

namespace TestTaskManeraiInc
{
    public class PunchPosition : PunchBaseAnimation
    {
        private Vector3 _initialPosition;
        
        private void Start()
        {
            _initialPosition = transform.localPosition;
        }
        
        public void Punch(Vector3 direction)
        {
            StopTween();
            
            _tween = transform.DOPunchPosition(direction * punchPower, punchDuration)
                .SetEase(Ease.OutQuad)
                .OnComplete(SetInitialPosition);
        }

        private void SetInitialPosition()
        {
            transform.localPosition = _initialPosition;
        }
    }
}