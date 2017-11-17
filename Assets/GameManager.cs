using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	UIManager manager;

	void Start()
	{
		manager = FindObjectOfType<UIManager> ();
	}

	public void RefreshButton()
	{
		StartCoroutine ("RefreshButtonCO");
		manager.refreshButton.interactable = false;
	}

	IEnumerator RefreshButtonCO()
	{
		WWW www = new WWW(manager.url);
		yield return www;

		// Modified the JSON String.
		// Unity "JsonUtility" does not support JSON array in top levels.
		string newJSONString = "{ \"lang\": " + www.text + " }";
		string data = newJSONString;

		JSON json = JSON.CreateFromJSON (data);

		manager.mainLangText.text = json.lang [0].question;

		for (int i = 0; i < json.lang[0].choices.Length; i++) {
			GameObject o = GameObject.Find (json.lang [0].choices [i].choice) as GameObject;
			if (o == null) {
				GameObject newPrefab = Instantiate (manager.langPrefab, manager.childObject) as GameObject;
				newPrefab.name = json.lang [0].choices [i].choice;
				PrefabElements elements = newPrefab.GetComponent<PrefabElements> ();
				elements.langNameText.text = json.lang [0].choices [i].choice;
				elements.langCountText.text = json.lang [0].choices [i].votes;
			}
		}
		manager.refreshButton.interactable = true;
	}
}