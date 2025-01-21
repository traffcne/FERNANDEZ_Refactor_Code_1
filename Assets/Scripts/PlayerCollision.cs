using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Collision")]
    [SerializeField] LayerMask wallLayer;

    [Header("Effects")]
    [SerializeField] private ParticleSystem partSys;

    private void PlayParticleEffect()
    {
        partSys.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((wallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            PlayParticleEffect();
        }
    }
}
