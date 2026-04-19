using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChecklistManager : IInitializable, IDisposable, ITickable
{
    [Inject] readonly List<ChecklistStep> _checklistSteps;
    [Inject] readonly ElementRegistry _elementRegistry;

    private int _currentStepIndex = 0;
    private bool _isInitialized = false;
    
    private ChecklistStep CurrentStep => (_currentStepIndex < _checklistSteps.Count) ? _checklistSteps[_currentStepIndex] : null;
    
    private IToggleable _currentToggleable;
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
            if(_checklistSteps.Count > 0) SubscribeToCurrentStep();

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
            Debug.LogError($"[Checklist] Элемент {step.TargetElementID} не найден в реестре в момент подписки!");
            return;
        }

        if (element is IToggleable toggleable)
        {
            _currentToggleable = toggleable;
            toggleable.OnStateChanged += OnElementChanged;
        }
        else if (element is INormalizedElement normalizedElement)
        {
            _currentNormalizedElement = normalizedElement;
            normalizedElement.OnValueChanged += OnElementValueChanged;
        }
        
        // Debug.Log($"Subscribed to checklist step {_checklistSteps[_currentStepIndex].Description}");
    }

    private void OnElementChanged(bool newState)
    {
        var currentStep = CurrentStep;
            if (newState == currentStep.RequiredState && CurrentStep != null)
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
        if(_currentToggleable != null) _currentToggleable.OnStateChanged -= OnElementChanged;
        if(_currentNormalizedElement != null) _currentNormalizedElement.OnValueChanged -= OnElementValueChanged;

        _currentToggleable = null;
        _currentNormalizedElement = null;
    }

    private void DebugAllSteps()
    {
        for(int i = 0; i < _checklistSteps.Count; i++)
        {
            Debug.Log($"<color=red> step {i}: {_checklistSteps[i].Description} (Target: {_checklistSteps[i].TargetElementID})</color>");
        }
    }
    
    public void Dispose() => Unsubscribe();
}
