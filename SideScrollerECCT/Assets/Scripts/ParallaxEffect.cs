using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _parallaxStrength; //Чем глубже объект от камеры, тем больше значение СилыПараллакса
    [SerializeField] private bool _disableVerticalParallax = true; //Если true, то фоновый объект при прыжке двигаться не будет
    [SerializeField] private bool _moveRight = true; //Элементы фона будут двигаться за персонажем. Если false, то в противоположную сторону
    private Vector3 _targetPreviousPosition;
    private Transform _followingTarget;

    private void Start()
    {
        if (_followingTarget == null)
        {
            _followingTarget = Camera.main.transform;
        }
        _targetPreviousPosition = _followingTarget.position;
    }

    private void Update()
    {
        var delta = _followingTarget.position - _targetPreviousPosition;
        if (_disableVerticalParallax)
        {
            delta.y = 0;
        }

        _targetPreviousPosition = _followingTarget.position;
        if (_moveRight)
        {
            transform.position += delta * _parallaxStrength;
        }
        else
        {
            transform.position -= delta * _parallaxStrength;
        }
    }
}
