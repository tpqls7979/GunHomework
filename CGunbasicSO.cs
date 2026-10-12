using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGunbasicSO : MonoBehaviour
{
    [SerializeField] private CGunBasic _weapon = null;
    [SerializeField] private float _bulletDestroy = 5f;

    void Start()
    {
        if (_weapon == null)
        {
            return;
        }

        transform.localScale = Vector3.one * _weapon.weaponScale;


        Destroy(gameObject, _bulletDestroy);

    }

    void Update()
    {
        if ( _weapon == null )
        {
            return;
        }

        transform.Translate(Vector3.forward * _weapon.weaponSpeed * Time.deltaTime);

        
    }
}
