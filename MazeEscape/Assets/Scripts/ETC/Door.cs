using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;

    public bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DoorOpen()
    {
        _animator.SetBool("isOpen", true);
    }

    public void DoorClose()
    {
        _animator.SetBool("isOpen", false);
    }
}
