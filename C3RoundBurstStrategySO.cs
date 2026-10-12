using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/C3RoundBurst", fileName = "C3RoundBurstStrategy_")]
public class C3RoundBurstStrategySO : CFireStrategySO
{
    #region
    [SerializeField] private int _BurstCount = 3;
    [SerializeField] private float _BurstTimer = 0.2f;
    #endregion


    public override async UniTask FireAsync(CWeaponFireContext context, CancellationToken ct)
    {
        for (int i = 0; i < _BurstCount; i++)
        {

            context.Spawn(context.FireTransform.rotation);

            if (i < _BurstCount - 1)
            {

                // ¹æ½Ä ??
               
            }
        }
    }

}
