using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private string _blendAnimation;

    private Animator _animator;
    private int _blendAnimationHash;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _blendAnimationHash = Animator.StringToHash(_blendAnimation);
    }

    private void Start()
    {
        _animator.SetFloat(_blendAnimationHash, 0.7f);
    }

}
