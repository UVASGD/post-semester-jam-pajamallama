using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Tuple {
	public Tag tag;
	public GameObject prefab;
}

public class ItemDictionary : MonoBehaviour {
	[SerializeField] private List<Tuple> items;
	private Dictionary<Tag, GameObject> itemDictionary;

	private void Awake () {
		FillDictionary();
	}

	private void FillDictionary () {
		foreach (var tuple in items) {
			if (tuple.prefab) {
				itemDictionary.Add(tuple.tag, tuple.prefab);
			}
		}
	}

	public GameObject GetPrefabFromTag (Tag tag) {
		try {
			return itemDictionary[tag];
		}
		catch {
			return null;
		}
	}
}