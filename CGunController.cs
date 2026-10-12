using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CGunController : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _fireTransform = null;
    [SerializeField] CGunBasic _weaponData;
    [SerializeField] CFireStrategySO _fireStrategy = null;
    CancellationToken ct;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShotAsync(ct).Forget(); 
        }
    }

    private async UniTask ShotAsync(CancellationToken ct)
    {
        if (_bulletPrefab == null || _fireTransform == null)
        {
            Debug.Log("ø¨∞· ¿ŒΩ∫∆—≈Õ »Æ¿Œ (√—æÀ / √—±∏)");
            return;
        }

        CWeaponFireContext context = new CWeaponFireContext(_weaponData, _fireTransform, Spawnbullet);

        await _fireStrategy.FireAsync(context, ct);

    }

    private void Spawnbullet(Quaternion spawnRotation)
    {
        Instantiate(_bulletPrefab, _fireTransform.position,spawnRotation );

    }
}
