using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResolutionSetting", menuName = "Collection/ResolutionSetting")]
public class ResolutionSetting : ScriptableObject
{
    [System.Serializable]
    public class ResolutionData
    {
        public Vector2 refResolution;
        public Vector2 PortraitMaxHeightResolution;
        public Vector2 PortraitMinHeightResolution;

        public ResolutionData()
        {
            refResolution = Vector2.zero;
            PortraitMaxHeightResolution = Vector2.zero;
            PortraitMinHeightResolution = Vector2.zero;
        }
    }

    public ResolutionData resSetting;
}
