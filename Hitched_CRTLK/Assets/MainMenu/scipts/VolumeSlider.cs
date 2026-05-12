using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
    private MusicManager musicManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;

        // MusicManager 찾기 (Instance가 null이면 직접 찾기)
        musicManager = MusicManager.Instance;
        if (musicManager == null) musicManager = FindObjectOfType<MusicManager>();

        if (musicManager == null)
        {
            Debug.LogWarning("VolumeSlider: 씬에서 MusicManager를 못 찾음!");
            return;
        }

        // 저장된 볼륨으로 슬라이더 초기 위치 맞추기
        slider.SetValueWithoutNotify(musicManager.CurrentVolume);

        slider.onValueChanged.AddListener(OnVolumeChanged);
        Debug.Log($"VolumeSlider 연결 완료, 현재 볼륨: {musicManager.CurrentVolume}");
    }

    void OnVolumeChanged(float value)
    {
        Debug.Log($"슬라이더 값 변경됨: {value}");
        if (musicManager != null)
        {
            musicManager.SetVolume(value);
        }
    }

    void OnDestroy()
    {
        if (slider != null)
            slider.onValueChanged.RemoveListener(OnVolumeChanged);
    }
}