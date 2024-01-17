using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffectOnClick : MonoBehaviour
{
    public string tagSFX;

    public void PlaySFX()
    {
        SoundManager.Instance.PlaySound(tagSFX);
    }
}
