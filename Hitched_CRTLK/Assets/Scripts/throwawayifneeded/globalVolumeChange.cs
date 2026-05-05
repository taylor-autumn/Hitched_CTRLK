using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class globalVolumeChange : MonoBehaviour
{
    public List <Volume> globalVolume;
    private List <Vignette> vignette = new List<Vignette>();
    public bool turnOffFog = false;
    public float fadeSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Volume vol in globalVolume)
        {
            if (vol.profile.TryGet(out Vignette vig))
            {
                vig.intensity.overrideState = true;
                vignette.Add(vig);
            }
        }
    }

void Update()
{
    if (turnOffFog)
    {
        bool done = true;

        foreach (Vignette vig in vignette)
        {
            print("lol");
            vig.intensity.value = Mathf.MoveTowards(vig.intensity.value, 0f, fadeSpeed * Time.deltaTime);

            if (vig.intensity.value > 0f)
                {
                    done = false;
                }
        }
        if (done == true)
        {
            turnOffFog = false;
        }
    }
}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            turnOffFog = true;
        }
    }
}
