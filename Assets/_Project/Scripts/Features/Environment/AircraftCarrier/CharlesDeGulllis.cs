using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TheChecklist.Features.Environment.AircraftCarrier
{

    public class CharlesDeGulllis : MonoBehaviour
    {
        [Header("Radar Rotation")]
        [SerializeField] private Transform _radarParent;
        [SerializeField] private float _radarRotationSpeed;

        [Header("Carrier rocking")]
        [SerializeField] private float _rollAngle = 0.25f;
        [SerializeField] private float _cycleDuration = 7f; 

        void Start()
        {
            transform.DOLocalRotate(new Vector3(0, 0, _rollAngle), _cycleDuration)
                .From(new Vector3(0, 0, -_rollAngle)) 
                .SetEase(Ease.InOutSine)             
                .SetLoops(-1, LoopType.Yoyo);       
        }


        void Update()
        {
            _radarParent.Rotate(Vector3.up * Time.deltaTime * _radarRotationSpeed);
        }
    }

}
