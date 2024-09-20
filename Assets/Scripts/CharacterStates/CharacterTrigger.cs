using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterTrigger : MonoBehaviour
{
    public event UnityAction FinishTriggered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Finish finish))
        {
            FinishTriggered?.Invoke();
        }
    }
}
