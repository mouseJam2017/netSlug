using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CfgWeapon : IDataElement
{
	public enum WeaponType
	{
		Simple=9,
		Lobbed
	}

	public string m_id = "new_weapon";

	public GameObject m_projectilePrefab = null;
	public GameObject m_impactPrefab = null;
	public AudioClip m_fireSound = null;

	public float m_muzzleVelocity = 10.0f;
	public float m_lifespan = 1.0f; // 0 means never die
	public float m_reload = 0.2f; // 0 means no automatic fire
	public float m_overrideFiringAngle = 0.0f; // 0 means fire at cursor
	public int m_ammoMax = 0; // 0 means unlimited ammo

	public string ID { get { return m_id; } }
}
