using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpeningMenuIntro : MonoBehaviour
{
    [Header("Fade In (전체 화면)")]
    [Tooltip("화면 전체를 덮는 검은색 Image (CanvasGroup 컴포넌트 필요)")]
    public CanvasGroup fadeOverlay;
    public float fadeInDuration = 1.0f;

    [Header("로고")]
    [Tooltip("로고 RectTransform")]
    public RectTransform logoRect;
    [Tooltip("로고 CanvasGroup (없으면 자동 추가)")]
    public CanvasGroup logoGroup;
    public float logoDuration = 0.8f;
    [Tooltip("시작 시 가로 압축 비율 (0에 가까울수록 더 압축)")]
    [Range(0f, 1f)] public float logoStartXScale = 0.05f;

    [Header("버튼들 (등장 순서대로)")]
    public CanvasGroup[] buttons;
    public float buttonFadeDuration = 0.4f;
    [Tooltip("버튼들 사이 시간차")]
    public float buttonStagger = 0.15f;

    [Header("타이밍")]
    [Tooltip("페이드인 끝나고 로고 시작까지 대기")]
    public float delayBeforeLogo = 0.2f;
    [Tooltip("로고 끝나고 버튼 시작까지 대기")]
    public float delayBeforeButtons = 0.2f;

    void Start()
    {
        // 초기 상태 세팅
        if (fadeOverlay != null)
        {
            fadeOverlay.alpha = 1f;
            fadeOverlay.blocksRaycasts = true;
        }

        if (logoRect != null)
        {
            if (logoGroup == null) logoGroup = logoRect.GetComponent<CanvasGroup>();
            if (logoGroup == null) logoGroup = logoRect.gameObject.AddComponent<CanvasGroup>();
            logoGroup.alpha = 0f;
            logoRect.localScale = new Vector3(logoStartXScale, 1f, 1f);
        }

        foreach (var btn in buttons)
        {
            if (btn != null)
            {
                btn.alpha = 0f;
                btn.interactable = false;
                btn.blocksRaycasts = false;
            }
        }

        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        // 1. 전체 화면 페이드인
        if (fadeOverlay != null)
        {
            yield return StartCoroutine(FadeCanvasGroup(fadeOverlay, 1f, 0f, fadeInDuration));
            fadeOverlay.blocksRaycasts = false;
            fadeOverlay.gameObject.SetActive(false);
        }
        MusicManager mm = MusicManager.Instance;
        if (mm == null) mm = FindObjectOfType<MusicManager>();

        if (mm != null)
        {
            Debug.Log("음악 재생 호출됨!");
            mm.PlayWithFadeIn();
        }
        else
        {
            Debug.Log("씬에서 MusicManager를 못 찾음!");
        }
        
        yield return new WaitForSeconds(delayBeforeLogo);

        // 2. 로고: 가로 압축 -> 원본 비율로 펼쳐지면서 페이드인
        if (logoRect != null)
        {
            logoGroup.alpha = 1f;
            float t = 0f;
            while (t < logoDuration)
            {
                t += Time.deltaTime;
                float p = Mathf.Clamp01(t / logoDuration);
                float eased = EaseOutBack(p);
                float xScale = Mathf.LerpUnclamped(logoStartXScale, 1f, eased);
                logoRect.localScale = new Vector3(xScale, 1f, 1f);
                yield return null;
            }
            logoRect.localScale = Vector3.one;
        }

        yield return new WaitForSeconds(delayBeforeButtons);

        // 3. 버튼들: 순차적으로 페이드인
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == null) continue;
            StartCoroutine(FadeInButton(buttons[i], buttonFadeDuration));
            yield return new WaitForSeconds(buttonStagger);
        }
    }

    IEnumerator FadeInButton(CanvasGroup cg, float duration)
    {
        yield return StartCoroutine(FadeCanvasGroup(cg, 0f, 1f, duration));
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float t = 0f;
        cg.alpha = from;
        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
        cg.alpha = to;
    }

    float EaseOutBack(float x)
    {
        const float c1 = 1.70158f;
        const float c3 = c1 + 1f;
        return 1f + c3 * Mathf.Pow(x - 1f, 3f) + c1 * Mathf.Pow(x - 1f, 2f);
    }
}