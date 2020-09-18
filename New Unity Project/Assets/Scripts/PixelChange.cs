using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelChange : MonoBehaviour
{
    public RenderTexture renderTexture; // renderTextuer that you will be rendering stuff on
    public Renderer renderer; // renderer in which you will apply changed texture
    Texture2D texture;

    void Start()
    {

        texture = new Texture2D(renderTexture.width, renderTexture.height);
        renderer.material.mainTexture = texture;
        //make texture2D because you want to "edit" it. 
        //however this is not a way to apply any post rendering effects because
        //this way, you are reading it through CPU(slow).
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfor;

            if (Physics.Raycast(ray, out hitinfor))
            {

                int x = (int)(renderTexture.width * hitinfor.textureCoord.x);
                int y = (int)(renderTexture.height * hitinfor.textureCoord.y);

                RenderTexture.active = renderTexture;
                //don't forget that you need to specify rendertexture before you call readpixels
                //otherwise it will read screen pixels.
                //texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 20; j++)
                    {
                        texture.SetPixel(x + i, y + j, new Color(1, 0, 0));
                    }
                texture.Apply();
                RenderTexture.active = null; //don't forget to set it back to null once you finished playing with it. 
            }
        }
    }
}
