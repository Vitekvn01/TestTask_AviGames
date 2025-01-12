using UnityEngine;

public class SoundController : MonoBehaviour, ISound
{
    [SerializeField] private AudioClip _click;
    [SerializeField] private AudioClip _rope;
    [SerializeField] private AudioSource _clickSource;
    [SerializeField] private AudioSource _ropeSource;

    private void Start()
    {
        _ropeSource.clip = _rope;
    }
    public void PlayClick()
    {
        _clickSource.PlayOneShot(_click);
    }

    public void PlayRope()
    {
        _ropeSource.loop = true;
        _ropeSource.Play();
    }

    public void StopRope()
    {
        _ropeSource.Stop();
    }
}
