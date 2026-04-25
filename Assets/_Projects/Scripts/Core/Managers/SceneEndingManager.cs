using System;
using TheChecklist.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using Zenject;

namespace TheChecklist.Core.Managers
{
    public class SceneEndingManager : MonoBehaviour
    {
        [Inject] private ChecklistManager _checklistManager;
    
        [SerializeField] private PlayableDirector _flightTimeline;
        [SerializeField] private string _creditsSceneName = "CreditsScene";

        private void OnEnable()
        {
            _checklistManager.OnChecklistComplete += StartFlightSequence;
        }

        private void OnDisable()
        {
            _checklistManager.OnChecklistComplete -= StartFlightSequence;
        }

        public void StartFlightSequence()
        {
            if (_flightTimeline != null)
            {
                _flightTimeline.Play();
            
                _flightTimeline.stopped += OnTimelineStopped;
            }
        }

        private void OnTimelineStopped(PlayableDirector director)
        {
            SceneManager.LoadScene(_creditsSceneName);
        }
    
        private void OnDestroy()
        {
            if (_flightTimeline != null)
                _flightTimeline.stopped -= OnTimelineStopped;
        }
    }
}
