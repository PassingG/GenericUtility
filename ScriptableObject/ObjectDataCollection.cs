using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDataCollection", menuName = "Collection/ObjectDataCollection")]
public class ObjectDataCollection : ScriptableObject
{
    [System.Serializable]
    public class Data
    {
        public Data()
        {
            key = string.Empty;
            objectData = null;
            prefab = null;
            iconPrefab = null;
        }

        public string key;
        public ObjectDataScriptableObject objectData;
        public GameObject prefab;
        public GameObject iconPrefab;

        /// <summary>
        /// Get ObjectType after insert key.
        /// </summary>
        /// <returns> ObjectType </returns>
        public ObjectType GetObjectTypeInsertKey()
        {
            ObjectType objectTypeTmp = objectData.objectData;
            objectTypeTmp.id = key;

            return objectTypeTmp;
        }
    }

    [SerializeField]
    public List<Data> datas = new List<Data>();
}
