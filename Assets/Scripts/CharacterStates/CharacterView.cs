using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private const string IsIdling = "IsIdling";
    private const string IsMoving = "IsMoving";
    private const string IsDancing = "IsDancing";
    
    [Header("References: ")] 
    [SerializeField] private ParticleSystem _moneyVfx;
    [SerializeField] private ParticleSystem _bottleVfx;
    [SerializeField] private List<GameObject> _skins;

    private int _currentSkinIndex = 0;
    private Animator _animator;

    public void Initialize() => _animator = GetComponentInChildren<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);
    
    public void StartMoving() => _animator.SetBool(IsMoving, true);
    public void StopMoving() => _animator.SetBool(IsMoving, false);
    
    public void StartDancing() => _animator.SetBool(IsDancing, true);
    public void StopDancing() => _animator.SetBool(IsDancing, false);

    public void OnPickupTriggered(PickupType pickupType)
    {
        switch (pickupType)
        {
            case PickupType.Money:
                _moneyVfx.Play();
                break;
            case PickupType.Bottle:
                _bottleVfx.Play();
                break;
        }
    }

    public void ChangeToNextSkin()
    {
        if (_currentSkinIndex + 1 < _skins.Count)
        {
            _currentSkinIndex++;
        }
        
        _skins[_currentSkinIndex - 1].SetActive(false);
        _skins[_currentSkinIndex].SetActive(true);        
    }
}