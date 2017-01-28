using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : BaseProgressionManager
{
	private DataManager<CfgClass> _classes = new DataManager<CfgClass>();
	public DataManager<CfgClass> Classes { get { return _classes; } }

	private DataManager<CfgRegion> _regions = new DataManager<CfgRegion>();
	public DataManager<CfgRegion> Regions { get { return _regions; } }

	private DataManager<CfgWeapon> _weapons = new DataManager<CfgWeapon>();
	public DataManager<CfgWeapon> Weapons { get { return _weapons; } }

	private CfgGeneral _general = null;
	public CfgGeneral General { get { return _general; } }

	#region BaseProgressionManager
	public override void LoadNeededAssets()
	{
		base.LoadNeededAssets();

		if( _general == null )
		{
			Debug.LogException (new System.Exception ("No general config found"));
		}
	}

	public override void ParseConfigBundle( IConfigBundle bundle )
	{
		ConfigBundle cfgBundle = bundle as ConfigBundle;
		_classes.PopulateWithList( cfgBundle.m_classes );
		_regions.PopulateWithList( cfgBundle.m_regions );
		_weapons.PopulateWithList( cfgBundle.m_weapons );

		if( cfgBundle.m_generals.Count > 0 )
		{
			if( _general != null )
			{
				Debug.LogException (new System.Exception ("Multiple general configs found"));
			}
			_general = cfgBundle.m_generals[0];
		}
	}
	#endregion
}
