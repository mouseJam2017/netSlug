using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CfgRegion : IDataElement
{
	public enum Type
	{
		Town=0,
		Arena
	}

	public string m_id = "new_region";
	public AudioClip m_music;
	public string m_unityScene;
	public Type m_type;

	public string ID { get { return m_id; } }
}
