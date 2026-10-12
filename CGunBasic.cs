using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponBasic", fileName = "WeaponBasic_")]
public class CGunBasic : ScriptableObject
{
    #region 인스펙터
    [SerializeField] private string _weaponName = "Gun";
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _weaponSpeed = 5f;
    [SerializeField] private float _weaponScale = 1f;


    #endregion

    #region 프로퍼티
    public string weaponName => _weaponName;
    public int damage => _damage;
    public float weaponSpeed => _weaponSpeed;
    public float weaponScale => _weaponScale;

    #endregion
}

