using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class ScaryScr : MonoBehaviour
{
    public float intensity = 0;

    //postProcessingVolume.profile.

    PostProcessVolume _volume;
    Vignette _vignette;

    public IEnumerator MonsterCloseEffect()
    {
        intensity = 0.6f;

        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.6f);

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0) intensity = 0;

            _vignette.intensity.Override(intensity);

            yield return new WaitForSeconds(0.1f);
        }

        _vignette.enabled.Override(false);
        yield break;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);

        if (!_vignette)
        {
            Debug.Log("error");
        }

        else
        {
            _vignette.enabled.Override(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
