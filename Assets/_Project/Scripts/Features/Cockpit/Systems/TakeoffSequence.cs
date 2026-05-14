using System.Collections;
using DG.Tweening;
using TheChecklist.Infrastructure;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace TheChecklist.Features.Cockpit.Systems
{
    public class TakeoffSequence : MonoBehaviour
    {
        [Header("Animation")]
        [SerializeField] private Transform _gForceParent;
        [SerializeField] private Volume _globalVolume;
        [SerializeField] private float _takeOffDuration = 2f;
        [SerializeField] private float _weightMin = 0.05f;
        [SerializeField] private float _weightMax = 1f;
        private Animator _animator;
        
        private static string _animationName = "TakeOff"; 
    
        [Inject] private PowerSystem _powerSystem;
    
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    
        public void PlayCatapultGForce()
        {
            StartCoroutine(PlayAndLoad(_animationName));
            
            _gForceParent.DOLocalMove(new Vector3(0, -0.05f, -0.15f), 0.1f)
                .SetEase(Ease.OutQuad);

            _gForceParent.DOShakeRotation(_takeOffDuration, new Vector3(2f, 2f, 1f), 20, 90, false)
                .SetEase(Ease.InQuad);

            _gForceParent.DOLocalMove(Vector3.zero, 0.5f)
                .SetDelay(_takeOffDuration)
                .SetEase(Ease.OutBack);

            DOTween.To(() => _globalVolume.weight, x =>
                {
                    _globalVolume.weight = x;

                }, _weightMax, _takeOffDuration).SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    DOTween.To(() => _globalVolume.weight, x =>
                    {
                        _globalVolume.weight = x;

                    }, _weightMin, _takeOffDuration * 2f).SetEase(Ease.OutQuad);
                });
        }
        
        private IEnumerator PlayAndLoad(string animationName)
        {
            _animator.Play(animationName);
    
            yield return null; 
    
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
    
            SceneLoader.LoadScene("CreditsScene");
        }
    }
}

