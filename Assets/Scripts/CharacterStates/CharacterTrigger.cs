using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterTrigger : MonoBehaviour
{
    public event UnityAction FinishTriggered;
    public event UnityAction<int, PickupType> PickupTriggered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Finish finish))
        {
            FinishTriggered?.Invoke();
        }
        
        if (other.TryGetComponent(out Pickup pickup))
        {
            PickupTriggered?.Invoke(pickup.PointsValue, pickup.PickupType);
        }
    }
}
