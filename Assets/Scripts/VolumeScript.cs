using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeScript : MonoBehaviour
{
    private Volume v;
    private DepthOfField depth;


    // Start is called before the first frame update
    void Start()
    {
        v = GetComponent<Volume>();
        v.profile.TryGet(out depth);
        
    }

    void Update()
    {
        if(depth.focalLength.value <= 30)
        {
            depth.focalLength.value += Time.deltaTime * 7.5f;
        }

    }

}
