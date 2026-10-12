using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/CHomingFire", fileName = "CHomingFireStrategy_")]
public class CHomingFireStrategySO : CFireStrategySO
{
    #region
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private float _angleOffset = 10f;
    [SerializeField] private LayerMask _targetLayer;
    #endregion


    public override async UniTask FireAsync(CWeaponFireContext context, CancellationToken ct)
    {
        Transform target = FindTargetRaycast(context.FireTransform);

        context.Spawn(context.FireTransform.rotation);

        await UniTask.CompletedTask;

    }

    private Transform FindTargetRaycast(Transform fireTransform)
    {
        Vector3 orgin = fireTransform.position;

        Vector3 forwardDir = fireTransform.forward;
        Vector3 rightDir = Quaternion.Euler(0, _angleOffset, 0) * fireTransform.forward;
        Vector3 leftDir = Quaternion.Euler(0, -_angleOffset, 0) * fireTransform.forward;


        Debug.DrawRay(orgin, forwardDir * _maxDistance, Color.red, 1f);
        Debug.DrawRay(orgin, rightDir * _maxDistance, Color.red, 1f);
        Debug.DrawRay(orgin, leftDir * _maxDistance, Color.red, 1f);

        if (Physics.Raycast(orgin, forwardDir, out RaycastHit hit , _maxDistance, _targetLayer))
        {
            return hit.transform;
        }

        if (Physics.Raycast(orgin, rightDir, out RaycastHit hitRight, _maxDistance, _targetLayer))
        {
            return hitRight.transform;
        }

        if (Physics.Raycast(orgin, leftDir, out RaycastHit hitLeft, _maxDistance, _targetLayer))
        {
            return hitLeft.transform;
        }


        return null;

    }

 

}
