using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [Header("References: ")] 
    [SerializeField] private ParticleSystem _moneyVfx;
    [SerializeField] private ParticleSystem _bottleVfx;
    
    private const string IsIdling = "IsIdling";
    private const string IsMoving = "IsMoving";

    private Animator _animator;

    public void Initialize() => _animator = GetComponentInChildren<Animator>();

    public void StartIdling() => _animator.SetBool(IsIdling, true);
    public void StopIdling() => _animator.SetBool(IsIdling, false);
    
    public void StartMoving() => _animator.SetBool(IsMoving, true);
    public void StopMoving() => _animator.SetBool(IsMoving, false);

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
}