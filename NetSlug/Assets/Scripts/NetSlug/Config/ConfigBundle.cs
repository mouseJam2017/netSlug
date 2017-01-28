using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "cfg000", menuName = "Bundles/ConfigBundle", order = 1)]
[System.Serializable]
public class ConfigBundle : ScriptableObject, IConfigBundle
{
	public List< CfgGeneral > m_generals = new List< CfgGeneral >();
	public List< CfgRegion > m_regions = new List< CfgRegion >();
	public List< CfgWeapon > m_weapons = new List< CfgWeapon >();
	public List< CfgClass > m_classes = new List< CfgClass >();
}
