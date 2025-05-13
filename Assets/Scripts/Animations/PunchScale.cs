using DG.Tweening;
using UnityEngine;

namespace TestTaskManeraiInc
{
    public class PunchScale : PunchBaseAnimation
    {
        private Vector3 _initialScale;
        
        private void Start()
        {
            _initialScale = transform.localScale;
        }
        
        public void Punch()
        {
            StopTween();
            
            _tween = transform.DOPunchScale(Vector3.one * punchPower, punchDuration)
                .OnComplete(SetInitialScale);
        }
        
        private void SetInitialScale()
        {
            transform.localScale = _initialScale;
        }
    }
}
