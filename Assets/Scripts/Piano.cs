using UnityEngine;

public class Piano : MonoBehaviour, IInteractable {

    AudioSource source;
    AudioClip[] clips = new AudioClip[4];

    private void Start() {
        clips[0] = Resources.Load<AudioClip>("Sfxs/key1");
        clips[1] = Resources.Load<AudioClip>("Sfxs/key2");
        clips[2] = Resources.Load<AudioClip>("Sfxs/key3");
        clips[3] = Resources.Load<AudioClip>("Sfxs/key4");

        source = GetComponentInChildren<AudioSource>();

        source.Stop();
    }

    public void Interact() {
        Play();
    }

    public void Play() {
        source.clip = clips[Random.Range(0, 4)];
        source.Play();
    }

}
