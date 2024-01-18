using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    // Start is called before the first frame update
    private static Bgm instance;

    public static Bgm Instance
    {
        get { return instance; }
    }

    public AudioClip bgmClip; // 通过 Unity 编辑器直接设置

    private AudioSource audioSource;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;

        if (bgmClip != null)
        {
            audioSource.clip = bgmClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("BGM clip not assigned!");
        }
    }
}
