using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChecklistStepData", menuName = "ScriptableObjects/Data/ChecklistStepData")]
public class ChecklistStep : ScriptableObject
{
    [SerializeField, TextArea(2,2)] private string _description;
    public string Description => _description;
    [SerializeField] private string _targetElementID;
    public string TargetElementID => _targetElementID;
    [SerializeField] private bool _requiredState;
    public bool RequiredState => _requiredState;
    [SerializeField] private float _requiredValue;
    public float RequiredValue => _requiredValue;
}
