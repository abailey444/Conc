using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class ScaryScr : MonoBehaviour
{
    public float intensity = 0;
    private Volume postProcessingVolume;

    private VolumeProfile postProcessingMain;

    //postProcessingVolume.profile = postProcessingMain;

    Volume _volume;
    Vignette _vignette;

    public Camera mainCam;

    public IEnumerator MonsterCloseEffect()
    {




        intensity = 1f;

        //_vignette.enabled.Override(true);
        _vignette.intensity.value = 1;

        yield return new WaitForSeconds(0.4f);

        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0) intensity = 0;

            _vignette.intensity.value = 1f;

            yield return new WaitForSeconds(0.1f);
        }

        _vignette.intensity.value = 0f;
        yield break;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<Volume>();
        _volume.profile.TryGet<Vignette>(out _vignette);

        //postProcessingMain = GetComponent<VolumeProfile>();
        //postProcessingMain.TryGet(out _vignette);


        if (!_vignette)
        {
            Debug.Log("error");
        }

        else
        {
            _vignette.intensity.value = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
