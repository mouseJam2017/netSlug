using UnityEngine;
using System.Collections;

public class PhaseLoadData : IPhase
{
	#region IPhase
	public void Setup( BaseAppManager app )
	{
		AppManager appCast = app as AppManager;

		appCast.ProgressionManager.LoadNeededAssets();
	}

	public void UpdateFixed( float dt )
	{
	}

	public bool UpdateFrame( float dt )
	{
		return true;
	}

	public void Teardown()
	{
	}
	#endregion
}
