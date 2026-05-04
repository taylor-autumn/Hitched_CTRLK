using UnityEngine;

public class mazeWalls : MonoBehaviour
{
    public float fadeSpeed = 0.25f;

    private Color transparentVar;
    private Color opaqueVar;
    private SpriteRenderer spriteRenderer;

    private float t;
    private bool fadingIn = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        transparentVar = new Color(1f, 1f, 1f, 0f);
        opaqueVar = new Color(1f, 1f, 1f, 1f);

        t = Random.Range(0f, 1f);
    }

    void Update()
    {
        if (fadingIn)
            t += Time.deltaTime * fadeSpeed;
        else
            t -= Time.deltaTime * fadeSpeed;

        t = Mathf.Clamp01(t);

        spriteRenderer.color = Color.Lerp(transparentVar, opaqueVar, t);

        if (t >= 1f) fadingIn = false;
        if (t <= 0f) fadingIn = true;
        if (t <= 0.2f)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}
