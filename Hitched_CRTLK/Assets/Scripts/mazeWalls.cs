using UnityEngine;

public class mazeWalls : MonoBehaviour
{
    public float fadeSpeed;
    Color transparentVar;
    Color OpaqueVar;
    Color lerpedShown = Color.white;
    Renderer renderering;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transparentVar = new Color(1f,1f,1f,0f);
        OpaqueVar = new Color(1f,1f,1f,1f);
        renderering = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float wallTransparency = Mathf.Sin(fadeSpeed);
        lerpedShown = Color.Lerp(transparentVar, OpaqueVar, 1/wallTransparency);
        renderering.material.color = lerpedShown;
    }
}
