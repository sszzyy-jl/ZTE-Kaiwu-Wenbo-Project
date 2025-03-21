using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip soundEffect;  // 音效剪辑
    private AudioSource audioSource;  // 音效源
    private bool isPlaying = false;  // 是否正在播放音效

    private void Start()
    {
        // 获取音效源组件
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // 如果角色没有音效源组件，则添加一个
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 将音效剪辑分配给音效源
        audioSource.clip = soundEffect;
    }

    private void OnMouseDown()
    {
        // 如果当前没有播放音效，则播放音效
        if (!isPlaying)
        {
            audioSource.Play();
            isPlaying = true;

            // 在音效播放完成后将isPlaying重置为false
            Invoke("ResetIsPlaying", audioSource.clip.length);
        }
    }

    private void ResetIsPlaying()
    {
        isPlaying = false;
    }
}
