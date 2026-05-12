using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Header("음악 설정")]
    public AudioClip backgroundMusic;
    [Range(0f, 1f)] public float defaultVolume = 0.5f;
    public float fadeInDuration = 1.0f;

    [Header("PlayerPrefs")]
    public string volumePrefKey = "BGMVolume";

    private AudioSource source;
    public float CurrentVolume { get; private set; }

    void Awake()
    {
        // 싱글톤
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        source = GetComponent<AudioSource>();
        if (source == null) source = gameObject.AddComponent<AudioSource>();

        source.clip = backgroundMusic;
        source.loop = true;
        source.playOnAwake = false;
        source.volume = 0f;

        // 저장된 볼륨 불러오기
        CurrentVolume = PlayerPrefs.GetFloat(volumePrefKey, defaultVolume);
        Debug.Log($"MusicManager Awake - 클립: {(backgroundMusic != null ? backgroundMusic.name : "없음")}, 볼륨: {CurrentVolume}");
    
    }

    /// <summary>
    /// 페이드인 하면서 음악 재생
    /// </summary>
    public void PlayWithFadeIn()
    {
        if (backgroundMusic == null) return;
        StopAllCoroutines();
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        source.volume = 0f;
        source.Play();

        float t = 0f;
        while (t < fadeInDuration)
        {
            t += Time.unscaledDeltaTime;
            float p = Mathf.Clamp01(t / fadeInDuration);
            source.volume = Mathf.Lerp(0f, CurrentVolume, p);
            yield return null;
        }
        source.volume = CurrentVolume;
    }

    /// <summary>
    /// 슬라이더에서 호출 (0~1)
    /// </summary>
    public void SetVolume(float volume)
    {
        CurrentVolume = Mathf.Clamp01(volume);
        source.volume = CurrentVolume;
        PlayerPrefs.SetFloat(volumePrefKey, CurrentVolume);
        PlayerPrefs.Save();
    }
}