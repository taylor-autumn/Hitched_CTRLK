using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    [Header("효과음")]
    public AudioClip hoverSound;
    public AudioClip clickSound;

    [Range(0f, 1f)] public float volume = 1f;

    private static AudioSource _sharedSource;

    void Awake()
    {
        if (_sharedSource == null)
        {
            GameObject go = new GameObject("[UI Sound Source]");
            _sharedSource = go.AddComponent<AudioSource>();
            _sharedSource.playOnAwake = false;
            DontDestroyOnLoad(go);
        }

        GetComponent<Button>().onClick.AddListener(PlayClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!GetComponent<Button>().interactable) return;
        if (hoverSound != null)
            _sharedSource.PlayOneShot(hoverSound, volume);
    }

    void PlayClick()
    {
        if (clickSound != null)
            _sharedSource.PlayOneShot(clickSound, volume);
    }
}