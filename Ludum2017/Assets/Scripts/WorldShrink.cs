using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class WorldShrink : NetworkBehaviour
{


    public float startSize = 1;

    public float minScale = 0.033f;

    private Vector3 _extra;

    private Vector3 _StartScale;

    private Vector3 _targetScale;

    public float speed = 2.0f;

    private float time = 0.0f;
    public float interpolationPeriod = 5;
    public float bang=1;



    void Start()
    {
        _extra = new Vector3(minScale,minScale,minScale);
        _StartScale = new Vector3(startSize, startSize, startSize);
        this.transform.localScale = _StartScale;
        _targetScale = this.transform.localScale - minScale * _extra;

    }

    //[ServerCallback]
    void Update()
    {
        if (!isServer)
            return;

        time += Time.deltaTime;

        //transform.localScale = Vector3.Lerp (transform.localScale, targetScale, speed * Time.deltaTime);

        if (time >= interpolationPeriod)
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.transform.localScale + _extra, speed * Time.deltaTime);
            if (time >= interpolationPeriod + bang)
            {
                this.transform.localScale = _targetScale;
                _targetScale = this.transform.localScale - minScale * _extra;

                time = 0.0f;
            }




        }
    }
}
