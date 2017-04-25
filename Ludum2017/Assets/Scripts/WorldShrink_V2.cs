using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class WorldShrink_V2 : NetworkBehaviour
{


    //private Vector3 _startSize = new Vector3(1,1,1);

    [SerializeField]
    private float _minScale = 5f;

    [SerializeField]
    private float _maxScaled = 30f;

    Vector3 transformScale = new Vector3(1, 1, 1);

    private Vector3 _extra;
    
    //private Vector3 _StartScale;

    private Vector3 _targetScale;

    [SerializeField]
    private float speed = 0.5f;

    private float time = 0.0f;

    [SerializeField]
    private float _shrinkPeriod = 10f;

    [SerializeField]
    private float bang=2;



    void Start()
    {
        _extra = new Vector3(0.05f, 0.05f, 0.05f);
        _minScale /= 100;
        _maxScaled /= 100;
        
        // _StartScale = this.transform.localScale;
        _targetScale = this.transform.localScale - (_minScale * Vector3.one) ;

    }

    [ServerCallback]
    void Update()
    {
        //Vector3 transformScale;

        Debug.Log(_minScale);


        if (this.transform.localScale.x > _maxScaled)
        {

            //Debug.Log("still shrinking");
            time += Time.deltaTime;


            if (time >= _shrinkPeriod)
            {
                transformScale = Vector3.Lerp(this.transform.localScale, this.transform.localScale + _extra, speed * Time.deltaTime);
                if (time >= _shrinkPeriod + bang)
                {
                    transformScale = _targetScale;
                    _targetScale -= (_minScale * Vector3.one);



                    time = 0.0f;
                }
            }
        }


        else
        {
            transformScale = new Vector3(_maxScaled, _maxScaled, _maxScaled);
            //Debug.Log("Done Shrinking");
        }
        
            
        

            RpcTransform(transformScale);
        
    }

    [ClientRpc]
    void RpcTransform(Vector3 T)
    {
        this.transform.localScale = T;

    }

}
