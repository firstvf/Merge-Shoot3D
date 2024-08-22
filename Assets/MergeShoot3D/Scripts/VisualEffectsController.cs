using UnityEngine;
using UnityEngine.VFX;

public class VisualEffectsController : MonoBehaviour
{
    private VisualEffect _vfx;

    private void Awake()
    {
        _vfx = GetComponent<VisualEffect>();
    }

    private void OnEnable()
    {
        _vfx.Stop();
    }

    public void PlayVFX()
    {
        _vfx.Play();
    }
}