using System.Collections.Generic;
using DG.Tweening;
using TheChecklist.Core;
using TheChecklist.Core.CockpitElements;
using TMPro;
using UnityEngine;
using Zenject;

namespace TheChecklist.Core.CockpitElements
{
    public class Clipboard : BaseCockpitElement
    {
        [Header("TMP Settings")]
        [SerializeField] private float _startTextPos = 0.24f;
        [SerializeField] private float _yOffset = 0.12f;
        [SerializeField] private int _maxStepsOnPage = 5;
        [SerializeField] private TextMeshPro _stepTMPPrefab;
        
        private Vector3 _startLocalPosition;
        private Vector3 _startLocalRotation;
        
        [Inject] private ChecklistManager _checklistManager;
        
        private List<TextMeshPro> _stepTMPs = new List<TextMeshPro>();
    
        private void Awake()
        {
            _startLocalPosition = transform.localPosition;
            _startLocalRotation = transform.localEulerAngles;
        }
        
        private void Start()
        {
            InitializeClipboar();
        }
    
        private void OnEnable()
        {
            _checklistManager.OnStateChanged += UpdateVisuals;
        }
    
        private void OnDisable()
        {
            _checklistManager.OnStateChanged -= UpdateVisuals;
        }
    
        private void InitializeClipboar()
        {
            for (int i = 0; i < _checklistManager.GetSteps().Count; i++)
            {
                TextMeshPro textMeshPro = Instantiate(_stepTMPPrefab, transform);
                _stepTMPs.Add(textMeshPro);
                textMeshPro.rectTransform.anchoredPosition = new Vector2(0, _startTextPos - (i * _yOffset));
            }
    
            UpdateVisuals();
        }
    
        private void UpdateVisuals()
        {
            int currentStep = _checklistManager.GetCurrentStep();
    
            for (int i = 0; i < _stepTMPs.Count; i++)
            {
                _stepTMPs[i].text = $"{_checklistManager.GetSteps()[i].Description}";
                
                if (i < currentStep)
                {
                    _stepTMPs[i].color = Color.green;
                    _stepTMPs[i].fontStyle = FontStyles.Strikethrough;
                }
                else if (i == currentStep)
                {
                    _stepTMPs[i].color = Color.red;
                    _stepTMPs[i].fontStyle = FontStyles.Bold;
                }
                else 
                {
                    _stepTMPs[i].color = Color.yellow;
                    _stepTMPs[i].fontStyle = FontStyles.Bold;
                }
            }
        }
    
        public override void OnInteract()
        {
            _isActive = !_isActive;
            
            Vector3 targetPos = _isActive ? _elementData.TargetPosition : _startLocalPosition;
            Vector3 targetRot = _isActive ? _elementData.TargetRotation : _startLocalRotation;
    
            Sequence sequence = DOTween.Sequence();
            
            sequence?.Kill(true);
            
            sequence.Append(transform.DOLocalMove(targetPos, _elementData.AnimationDuration));
            sequence.Join(transform.DOLocalRotate(targetRot, _elementData.AnimationDuration));
            sequence.SetEase(Ease.OutBack);
            
            sequence.OnComplete(() => Debug.Log($"Clipboard animation finished!"));
        }
    }
}

