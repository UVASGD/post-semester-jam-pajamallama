using System.Collections.Generic;
using UnityEngine;
public enum Tag
{
	Default,
	Bananas,
	Beer,
	CheeseCrack,
	Chips,
	HairStuff,
	Milk,
	Soda,
	Soup,
	SpiderEyeLube,
	UsedToiletPaper,
}

public class TagHandler : MonoBehaviour
{

    public List<Tag> tagList = new List<Tag>();

    public void Add(Tag tag)
    {
        tagList.Add(tag);
    }

    public void Add(List<Tag> tagList)
    {
        this.tagList.AddRange(tagList);
    }

    public void Remove(Tag tag)
    {
        tagList.Remove(tag);
    }

    public void RemoveAll(Tag tag)
    {
        tagList.RemoveAll(t => t == tag);
    }

    public void Clear() {
        tagList.Clear();
    }

    public bool HasTag(Tag tag)
    {
        return tagList.Contains(tag);
    }
}