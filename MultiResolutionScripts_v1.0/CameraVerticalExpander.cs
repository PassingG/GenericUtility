using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라의 영역을 가로 비율에만 맞춘다.
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraVerticalExpander : MonoBehaviour
{
    public ResolutionSetting.ResolutionData resData => AppManager.Instance.resScriptable.resSetting;

    public static Vector2 RefResolution => new Vector2(1440f, 2960f);

    private Vector2 PortraitMaxHeightResolution;
    private Vector2 PortraitMinHeightResolution;

    public Camera targetCamera { get; private set; }

    public bool ColorClear;

    public Color color = new Color(0f,0f,0f,1f);

    private void Start()
    {
        PortraitMaxHeightResolution = resData.PortraitMaxHeightResolution;
        PortraitMinHeightResolution = resData.PortraitMinHeightResolution;

        targetCamera = GetComponent<Camera>();

        OnChangedWindowSize();
    }

    private void OnChangedWindowSize()
    {
        Camera camera = targetCamera;
        Rect rect = camera.rect;

        float calculateResolutionX = 0f;
        float calculateResolutionY = 0f;

        // 가로 너비가 기준 값 보다 더 큰 경우
        float curScreenRatio = (float)Screen.width / Screen.height;

        float SafeAreaRatio = Screen.safeArea.width / Screen.safeArea.height;

        float heightMaxScreenRatio = PortraitMaxHeightResolution.x / PortraitMaxHeightResolution.y;
        float heightMinScreenRatio = PortraitMinHeightResolution.x / PortraitMinHeightResolution.y;

        if (curScreenRatio < 1)
        {
            calculateResolutionX = Screen.safeArea.width;
            calculateResolutionY = Screen.safeArea.height;

            if (SafeAreaRatio < heightMaxScreenRatio)
            {
                calculateResolutionY = (Screen.safeArea.width * PortraitMaxHeightResolution.y)/ PortraitMaxHeightResolution.x;
            }
            else if(SafeAreaRatio > heightMinScreenRatio)
            {
                calculateResolutionX = (Screen.safeArea.height * PortraitMinHeightResolution.x) / PortraitMinHeightResolution.y;
            }
        }
        else
        {
            calculateResolutionX = RefResolution.x;
            calculateResolutionY = RefResolution.y;
        }

        float scaleheight = curScreenRatio / (calculateResolutionX / calculateResolutionY); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;

        if (scaleheight >= 1)
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        else
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        camera.rect = rect;
    }

   private void OnPreCull()
    {
        Rect rect = new Rect(0, 0, 5000,5000);
        GL.Viewport(rect);
        GL.Clear(false, ColorClear, color, targetCamera.depth);
    }
}