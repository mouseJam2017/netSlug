using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: movie textures do not work in webGL.
// If the game is built for the WebGL platform this class will be wholesale ignored.
#pragma warning disable 0414

public class UIHubMovieEffect : MonoBehaviour, IHub
{
	private UnityEngine.UI.RawImage _movie = null;

	public void OnLevelChange( AppManager app )
	{
		#if UNITY_WEBGL
		#else
		_movie = GetComponent<UnityEngine.UI.RawImage>();
		#endif
	}

	public void UI( AppManager app )
	{
		#if UNITY_WEBGL
		#else
		if (_movie != null) 
		{
			Texture main = _movie.material.mainTexture;
			MovieTexture mainMovie = main as MovieTexture;
			_movie.enabled = mainMovie.isPlaying;
		}
		#endif
	}

	public void Play()
	{
		#if UNITY_WEBGL
		#else
		if (_movie != null)
		{
			Texture mask = _movie.material.GetTexture("_Mask");
			Texture main = _movie.material.mainTexture;
			MovieTexture maskMovie = mask as MovieTexture;
			MovieTexture mainMovie = main as MovieTexture;

			maskMovie.Stop ();
			maskMovie.Play ();

			mainMovie.Stop ();
			mainMovie.Play ();
		}
		#endif
	}
}
