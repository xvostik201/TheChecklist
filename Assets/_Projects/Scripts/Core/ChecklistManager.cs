using System;
using System.Collections;
using System.Collections.Generic;
using TheChecklist.Core.Data;
using TheChecklist.Installers;
using UnityEngine;
using Zenject;

namespace TheChecklist.Core
{
    public class ChecklistManager : IInitializable, IDisposable, ITickable
    {
        [Inject] readonly List<ChecklistStep> _checklistSteps;
        [Inject] readonly ElementRegistry _elementRegistry;
    
        private readonly Dictionary<IToggleableElement, Action<bool>> _toggleableDictionary = new();
        private readonly Dictionary<INormalizedElement, Action<float>> _normalizedDictionary = new ();
        
        private int _currentStepIndex = 0;
        private bool _isInitialized = false;
        
        private ChecklistStep CurrentStep => (_currentStepIndex < _checklistSteps.Count) ? _checklistSteps[_currentStepIndex] : null;
        
        private IToggleableElement _currentToggleableElement;
        private INormalizedElement _currentNormalizedElement;
    
        public ChecklistManager(List<ChecklistStep> checklistSteps, ElementRegistry elementRegistry)
        {
            _checklistSteps = checklistSteps;
            _elementRegistry = elementRegistry;
        }
        
        public void Initialize()
        {
            
        }
    
        public void Tick()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                if (_checklistSteps.Count > 0)
                {
                    SubscribeToAllStepElementsForRollback();
                    SubscribeToCurrentStep();
                }
    
                DebugAllSteps();
            }
        }
    
        private void SubscribeToCurrentStep()
        {
            Unsubscribe();
    
            var step = _checklistSteps[_currentStepIndex];
            var element = _elementRegistry.GetElement(step.TargetElementID);
            if (element == null) 
            {
                Debug.LogError($"[Checklist] Element {step.TargetElementID} don't exists on subscribe.");
                return;
            }
    
            if (element is IToggleableElement toggleable)
            {
                _currentToggleableElement = toggleable;
                toggleable.OnStateChanged += OnElementChanged;
            }
            else if (element is INormalizedElement normalizedElement)
            {
                _currentNormalizedElement = normalizedElement;
                normalizedElement.OnValueChanged += OnElementValueChanged;
            }
            
            Debug.Log($"<color=cyan><b>Subscribed to checklist step {_checklistSteps[_currentStepIndex].Description}</b></color>");
        }
    
        private void OnElementChanged(bool newState)
        {
            var currentStep = CurrentStep;
                if (CurrentStep != null && newState == currentStep.RequiredState)
                    CompleteStep(); 
        }
    
        private void OnElementValueChanged(float newValue)
        {
            if (CurrentStep != null)
            {
                var currentStep = CurrentStep;
                if (Mathf.Abs(currentStep.RequiredValue - newValue) <= 0.05f)
                    CompleteStep();
            }
        }
    
        private void CompleteStep()
        {
            Debug.Log($"<color=green>Step completed:</color> {_checklistSteps[_currentStepIndex].Description}");
            _currentStepIndex++;
    
            if (_currentStepIndex < _checklistSteps.Count)
                SubscribeToCurrentStep();
            else
                Debug.Log("<color=cyan><b>All Checklist completed!</b></color>");
        }
    
        private void Unsubscribe()
        {
            if(_currentToggleableElement != null) _currentToggleableElement.OnStateChanged -= OnElementChanged;
            if(_currentNormalizedElement != null) _currentNormalizedElement.OnValueChanged -= OnElementValueChanged;
    
            _currentToggleableElement = null;
            _currentNormalizedElement = null;
        }
    
        private void DebugAllSteps()
        {
            for(int i = 0; i < _checklistSteps.Count; i++)
            {
                Debug.Log($"<color=red> step {i}: {_checklistSteps[i].Description} (Target: {_checklistSteps[i].TargetElementID})</color>");
            }
        }

        private void ResetToStep(int index)
        {
            Debug.Log($"Current step index {_currentStepIndex}. RESET TO {index}: ");
            Debug.Log($"<color=red>Step reset to :</color> {_checklistSteps[index].Description}");
            _currentStepIndex = index;
            SubscribeToCurrentStep();
        }

        private void OnStateChange(string elementID, bool newState)
        {
            int stepIndex = _checklistSteps.FindIndex(s => s.TargetElementID == elementID);
            if (stepIndex == -1) return;

            Debug.Log($"Step {_checklistSteps[stepIndex].Description}! State changed to {newState}");
            
            if (stepIndex < _currentStepIndex && newState != _checklistSteps[stepIndex].RequiredState)
            {
                ResetToStep(stepIndex);
            }
        }

        private void OnStateChange(string elementID, float newStateValue)
        {
            int stepIndex = _checklistSteps.FindIndex(s => s.TargetElementID == elementID);
            if (stepIndex == -1) return;
            
            Debug.Log($"Step {_checklistSteps[stepIndex].Description}! State changed to {newStateValue}");

            if (stepIndex < _currentStepIndex &&
                Mathf.Abs(_checklistSteps[stepIndex].RequiredValue - newStateValue) > 0.05f)
            {
                ResetToStep(stepIndex);
            }
        }

        private void SubscribeToAllStepElementsForRollback()
        {
            foreach (var step in _checklistSteps)
            {
                var  element = _elementRegistry.GetElement(step.TargetElementID);
                if(element == null) continue;

                string targetID = step.TargetElementID;

                if (element is IToggleableElement toggleable)
                {
                    Action<bool> handler = (newState) => OnStateChange(targetID, newState);
                    toggleable.OnStateChanged += handler;
                    _toggleableDictionary[toggleable] = handler;
                }
                else if (element is INormalizedElement normalizedElement)
                {
                    Action<float> handler = (newValue) => OnStateChange(targetID, newValue);
                    normalizedElement.OnValueChanged += handler;
                    _normalizedDictionary[normalizedElement] = handler;
                }
            }
        }
        
        public void Dispose()
        { 
            Unsubscribe();
            foreach (var kvp in _toggleableDictionary)
            {
                kvp.Key.OnStateChanged -= kvp.Value;
            }

            foreach (var kvp in _normalizedDictionary)
            {
                kvp.Key.OnValueChanged -= kvp.Value;
            }
            
            _toggleableDictionary.Clear();
            _normalizedDictionary.Clear();
        }
    }
}

