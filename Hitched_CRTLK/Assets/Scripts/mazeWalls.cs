using UnityEngine;

public class mazeWalls : MonoBehaviour
{
    public float fadeSpeed;
    Color transparentVar;
    Color OpaqueVar;
    Color lerpedShown = Color.white;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transparentVar = new Color(1f,1f,1f,0f);
        OpaqueVar = new Color(1f,1f,1f,1f);
         GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeSpeed < 1)
        {
            fadeSpeed += Time.deltaTime;
        }
        Color lerpedShown = Color.Lerp(transparentVar, OpaqueVar, fadeSpeed);
        float wallTransparency = Mathf.Sin(fadeSpeed);
        spriteRenderer.color = lerpedShown;
    }
}
