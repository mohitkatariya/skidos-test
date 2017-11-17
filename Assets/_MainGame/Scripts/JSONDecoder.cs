using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSON
{
	public JSONDecoder[] lang;

	public static JSON CreateFromJSON(string data)
	{
		return JsonUtility.FromJson<JSON> (data);
	}
}

[System.Serializable]
public class JSONDecoder
{
	public string question;
	public string published_at;
	public ChoicesArray[] choices;

	public static JSONDecoder CreateFromJSON(string data)
	{
		return JsonUtility.FromJson<JSONDecoder> (data);
	}
}

[System.Serializable]
public class ChoicesArray
{
	public string choice;
	public string votes;

	public static ChoicesArray CreateFromJSON(string data)
	{
		return JsonUtility.FromJson<ChoicesArray> (data);
	}
}
