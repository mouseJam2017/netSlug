using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetSlugCharacter
{
	CfgClass m_class;
}

public class Enemy : NetSlugCharacter
{
}

public class User : NetSlugCharacter
{
}

public class GameState
{
	public string m_currentLoginName = "";
	public CfgGeneral m_generalConfig; 
	public string m_currentLevel = "";

	public Dictionary< string, NetSlugCharacter > m_characters = new Dictionary<string, NetSlugCharacter>();
}
