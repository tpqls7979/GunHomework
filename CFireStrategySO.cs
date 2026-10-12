using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class CWeaponFireContext
{
    public CGunBasic Weapon;
    public Transform FireTransform;
    public Action<Quaternion> Spawn;

    public CWeaponFireContext(CGunBasic weapon, Transform fireTransform, Action<Quaternion> spawn)
    {
        Weapon = weapon;
        FireTransform = fireTransform;
        Spawn = spawn;
    }
}

public abstract class CFireStrategySO : ScriptableObject
{
    public abstract UniTask FireAsync(CWeaponFireContext context, CancellationToken ct);
  
}