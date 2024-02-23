using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] private ParticleSystem starFeedback = default;

    public void PlayParticle(Vector3 screenPos)
    {
        starFeedback.transform.position = screenPos;
        starFeedback.Play();
    }
}
