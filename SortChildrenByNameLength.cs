using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public static class SortChildrenByNameLength
{
    public static void SortChildrenNameByNameLength(this Transform parent)
    {
        if (parent == null || parent.childCount <= 1) return;

        var children = new List<Transform>(parent.childCount);
        for (int i = 0; i < parent.childCount; i++)
            children.Add(parent.GetChild(i));

        var sorted = children
            .OrderBy(t => t.name)
            .ThenBy(t => t.name, System.StringComparer.Ordinal)
            .ToList();

        for (int i = 0; i < sorted.Count; i++)
            sorted[i].SetSiblingIndex(i);
    }
}
