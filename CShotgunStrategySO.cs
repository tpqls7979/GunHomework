using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/CShotgun", fileName = "CShotgun")]
public class CShotgunStrategySO : CFireStrategySO
{
    #region
    [SerializeField] private int _bulletCount = 3;
    [SerializeField] private float _spreadAngle = 10f;
    #endregion


    public override async UniTask FireAsync(CWeaponFireContext context, CancellationToken ct)
    {
        Quaternion BaseRotation = context.FireTransform.rotation;
  
        for (int i = 0; i < _bulletCount; i++)
        {
            float randomAnleX = Random.Range(-_spreadAngle * 0.5f , _spreadAngle * 0.5f);
            float randomAnleY = Random.Range(-_spreadAngle * 0.5f, _spreadAngle * 0.5f);

            Quaternion spreadRotation = BaseRotation * Quaternion.Euler(randomAnleX, randomAnleY, 0);

            context.Spawn(spreadRotation);
        }

        await UniTask.CompletedTask;

    }

}
