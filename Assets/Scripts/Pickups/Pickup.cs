using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupType pickupTypeType;
    [SerializeField] private GameObject _pickupModel;
    [SerializeField] private int _pointsValue;
    
    public PickupType PickupType => pickupTypeType;
    public int PointsValue => _pointsValue;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterTrigger player))
        {
            Debug.Log("Picked up!");
            // PlayVfx();
            _pickupModel.SetActive(false);
        }
    }
}
