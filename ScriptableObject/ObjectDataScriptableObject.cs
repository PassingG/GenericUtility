using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public enum EObject
{
    Building,
    Resource
}

[System.Serializable]
public struct ObjectType
{
    public string id;

    // In BiomGenerator Index
    public int objectIndex;

    public int2 size;
    public EBiom biomNum;

    public int neighborRadius;
    public int usageCost;
    public EObject objectType;
    public ObjectResourceData[] resourceData;

    public string GetLog()
    {
        string skillIds = string.Empty;
        foreach (var id in skillIds) skillIds += id + ", ";

        string rewardIds = string.Empty;
        foreach (var id in rewardIds) rewardIds += id + ", ";

        return $"ID({id})";
    }
}

[System.Serializable]
public struct ObjectResourceData
{
    public EResource resourceType;
    public int resourceAmount;
}

[CreateAssetMenu(fileName = "_Data", menuName = "ScriptableObject/ObjectData")]
public class ObjectDataScriptableObject : ScriptableObject
{
    [SerializeField]
    private ObjectType m_ObjectData;
    public ObjectType objectData => m_ObjectData;
}
