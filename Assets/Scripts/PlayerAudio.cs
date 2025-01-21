using Unity.VisualScripting;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Collision")]
    [SerializeField] LayerMask wallLayer;

    [Header("For Audio")]
    [SerializeField] private AudioSource audioSource;


    private void PlayAudio()
    {
        audioSource.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((wallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            PlayAudio();
        }
    }
}
