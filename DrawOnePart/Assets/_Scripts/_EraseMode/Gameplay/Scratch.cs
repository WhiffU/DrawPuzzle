using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : MonoBehaviour
{
    public SpriteMask spriteMask;
    public Camera spriteCam;

    public void AssignScreenAsMask()
    {
        int height = Screen.height;
        int width = Screen.width;
        int depth = 1;

        RenderTexture renderTexture = new RenderTexture(width, height, depth);
        Rect rect = new Rect(0, 0, width, height);
        Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, false);

        spriteCam.targetTexture = renderTexture;
        spriteCam.Render();

        RenderTexture currentRenderTexture = RenderTexture.active;
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(rect, 0, 0);
        texture2D.Apply();

        spriteCam.targetTexture = null;
        RenderTexture.active = currentRenderTexture;
        Destroy(renderTexture);

        Sprite sprite = Sprite.Create(texture2D, rect, new Vector2(.5f, .5f), Screen.height / 10);

        spriteMask.sprite = sprite;
    }
}