using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundScale : MonoBehaviour
{
    SpriteRenderer bgSprite;
    // Start is called before the first frame update
    void Start()
    {
        bgSprite = GetComponent<SpriteRenderer>();

        // Lấy kích thước của camera
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWitdh = cameraHeight * Camera.main.aspect;

        // Lấy kích thước hiện tại của background
        float bgHeight = bgSprite.sprite.bounds.size.y;
        float bgWitdh = bgSprite.sprite.bounds.size.x;

        // Tính tỷ lệ để scale bg
        float scaleX = cameraWitdh / bgWitdh;
        float scaley = cameraHeight / bgHeight;

        // Áp dụng tỷ lệ cho BG
        transform.localScale = new Vector3(scaleX, scaley, 1f);
    }
}
