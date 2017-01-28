using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CfgClass : IDataElement
{
	public string m_id = "new_class";

	public GameObject m_performerPrefab = null;
	public AudioClip m_jumpSound = null;

	public float m_maxHealth = 10.0f;
	public float m_walkSpeed = 2.0f;
	public float m_jumpStrength = 5.0f;

	public string ID { get { return m_id; } }
}
