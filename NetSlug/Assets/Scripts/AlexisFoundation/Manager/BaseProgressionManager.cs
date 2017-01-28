using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataElement
{
	string ID { get; }
}

public interface IConfigBundle
{
}

public class BaseProgressionManager : IManager
{
	public class InitData : ManagerInitData
	{
		public string[] m_neededAssetBundles;

		public InitData( BaseAppManager appManager )
		{
			BaseAppProxy.BaseConfiguration appConfig = appManager.AppProxyConfig as AppProxy.Configuration;

			m_neededAssetBundles = appConfig.m_neededAssetBundles;
		}
	}

	public class DataManager<T> where T : class, IDataElement
	{
		private Dictionary< string, T > _elements = new Dictionary<string, T>();

		public T GetById( string id )
		{
			if (!_elements.ContainsKey (id)) {
				Debug.LogException (new System.Exception ("Bad Id " + id));
			}
			return _elements[id];
		}

		public void PopulateWithList( List<T> src )
		{
			for( int i=0; i<src.Count; ++i )
			{
				T cfg = src[i];
				if( _elements.ContainsKey( cfg.ID ) )
				{
					Debug.LogWarning("Multiple entries found for ID: " + cfg.ID);
				}
				else
				{
					_elements[ cfg.ID ] = cfg;
				}
			}
		}

		public void Teardown()
		{
			_elements.Clear();
		}
	}

	public string[] _neededAssetBundles = null;

	#region IManager
	public virtual void Setup( ManagerInitData initData ) 
	{
		InitData data = initData as InitData;
		_neededAssetBundles = data.m_neededAssetBundles;
	}

	public void Teardown()
	{
	}
	public void UpdateFrame( float dt )
	{
	}
	public void UpdateFrameLate( float dt )
	{
	}
	public void UpdateFixed( float dt )
	{
	}

	#endregion

	public virtual void LoadNeededAssets()
	{
		for( int i=0; i<_neededAssetBundles.Length; ++i )
		{
			string assetBundleId = _neededAssetBundles[i];
			Object resource = Resources.Load( assetBundleId );

			if( resource is IConfigBundle )
			{
				ParseConfigBundle( resource as IConfigBundle );
			}
		}
	}

	public virtual void ParseConfigBundle( IConfigBundle bundle )
	{
	}
}