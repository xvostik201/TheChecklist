using System.Collections.Generic;
using DG.Tweening;
using TheChecklist.Core.Clipboard;
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
        
        [Header("Clipboard buttons")]
        [SerializeField] private ClipboardButton _nextPageButton;
        [SerializeField] private ClipboardButton _previewPageButton;
        
        private Vector3 _startLocalPosition;
        private Vector3 _startLocalRotation;
        
        [Inject] private ChecklistManager _checklistManager;
        
        private List<TextMeshPro> _stepTMPs = new List<TextMeshPro>();
        private Sequence _animationSequence;
        private int _currentPage = 0;
        private int _maxPages = 0;
    
        protected override void Awake()
        {
            _startLocalPosition = transform.localPosition;
            _startLocalRotation = transform.localEulerAngles;
        }
        
        private void Start()
        {
            InitializeClipboard();
        }
    
        private void OnEnable()
        {
            _checklistManager.OnStateChanged += UpdateVisuals;

            if (_nextPageButton != null && _previewPageButton != null)
            {
                _nextPageButton.OnClick += NextPage;
                _previewPageButton.OnClick += PrevPage;
            }
        }
    
        private void OnDisable()
        {
            _checklistManager.OnStateChanged -= UpdateVisuals;
            
            if (_nextPageButton != null && _previewPageButton != null)
            {
                _nextPageButton.OnClick -= NextPage;
                _previewPageButton.OnClick -= PrevPage;
            }
        }
    
        private void InitializeClipboard()
        {
            for (int i = 0; i < _checklistManager.GetSteps().Count; i++)
            {
                TextMeshPro textMeshPro = Instantiate(_stepTMPPrefab, transform);
                _stepTMPs.Add(textMeshPro);
            }
    
            _maxPages = (_stepTMPs.Count > 0) ? (_stepTMPs.Count - 1) / _maxStepsOnPage : 0;
            
            UpdateVisuals();
        }
    
        private void UpdateVisuals()
        {
            int currentStep = _checklistManager.GetCurrentStep();
    
            for (int i = 0; i < _stepTMPs.Count; i++)
            {
                bool isOnCurrentPage = (i / _maxStepsOnPage) == _currentPage;
                _stepTMPs[i].gameObject.SetActive(isOnCurrentPage);
                
                int indexOnPage = i % _maxStepsOnPage;
                _stepTMPs[i].rectTransform.anchoredPosition = new Vector2(0, _startTextPos - (indexOnPage * _yOffset));
                
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

            if (_nextPageButton != null && _previewPageButton != null)
            {
                _nextPageButton.gameObject.SetActive(_currentPage < _maxPages);
        
                _previewPageButton.gameObject.SetActive(_currentPage > 0);
            }
        }
    
        public override void OnInteract()
        {
            _isActive = !_isActive;
            
            Vector3 targetPos = _isActive ? _elementData.TargetPosition : _startLocalPosition;
            Vector3 targetRot = _isActive ? _elementData.TargetRotation : _startLocalRotation;
    
            _animationSequence?.Kill(true);
            
            _animationSequence = DOTween.Sequence();
            
            _animationSequence.Append(transform.DOLocalMove(targetPos, _elementData.AnimationDuration));
            _animationSequence.Join(transform.DOLocalRotate(targetRot, _elementData.AnimationDuration));
            _animationSequence.SetEase(Ease.OutBack);
            
            _animationSequence.OnComplete(() => Debug.Log($"Clipboard animation finished!"));
        }

        private void SwitchPage(bool nextPage)
        {
            _currentPage = nextPage ? _currentPage + 1 : _currentPage - 1;
            
            _currentPage = Mathf.Clamp(_currentPage, 0, _maxPages);

            UpdateVisuals();
        }

        private void NextPage() => SwitchPage(true);
        private void PrevPage() => SwitchPage(false);
    }
}

