using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShrink : MonoBehaviour
{


    public float startSize;

    public int minScale;

    private Vector3 _extra;

    private Vector3 _StartScale;

    private Vector3 _targetScale;

    public float speed = 2.0f;

    private float time = 0.0f;
    public float interpolationPeriod;
    public float bang;




    void Start()
    {
        _extra = new Vector3(2, 2, 2);
        _StartScale = new Vector3(startSize, startSize, startSize);
        this.transform.localScale = _StartScale;
        _targetScale = this.transform.localScale - minScale * _extra;

    }


    void Update()
    {


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
