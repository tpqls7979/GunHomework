using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/SingleFIreStrategy", fileName = "SingleFIreStrategy")]
public class CSingleFireStrategySO : CFireStrategySO
{
    public override async UniTask FireAsync(CWeaponFireContext context, CancellationToken ct)
    {
        context.Spawn(context.FireTransform.rotation);

        await UniTask.CompletedTask;
    }

}
