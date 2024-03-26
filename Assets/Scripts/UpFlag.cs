using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpFlag : MonoBehaviour

{
    bool _isEntre = false;
    [SerializeField] Animator _animator;
    private void OnTriggerEnter(Collider other)
    {
        _isEntre = true;
        _animator.CrossFade("FlagUp", 0.2f);
    }
}
