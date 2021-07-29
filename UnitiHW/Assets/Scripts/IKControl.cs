using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControl : MonoBehaviour
{
    [SerializeField]
    private bool _isActive;
    [SerializeField]
    private Transform _lookObject;
    [SerializeField]
    private Transform _pointHandObject;
    [SerializeField]
    private float _valueWeight;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_isActive)
        {            
             _animator.SetLookAtWeight(_valueWeight);
             _animator.SetLookAtPosition(_lookObject.position);

             ChangeWeightRightHand(_valueWeight);

             _animator.SetIKPosition(AvatarIKGoal.RightHand, _pointHandObject.position);
             _animator.SetIKRotation(AvatarIKGoal.RightHand, _pointHandObject.rotation);
        }
        else
        {
            ChangeWeightRightHand(0);
            _animator.SetLookAtWeight(0);
        }
    }  

private void ChangeWeightRightHand(float value)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, value);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, value);
    }
     
}
