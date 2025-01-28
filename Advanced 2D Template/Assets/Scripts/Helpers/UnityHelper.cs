using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Helpers
{
    public static class UnityHelper
    {
        public static Sprite SpriteFromScreenshot(string filePath, int width, int height, TextureFormat textureFormat, bool linear, Texture2D defaultTexture)
        {
            Debug.Log("Getting sprite from a screenshot");

            if (System.IO.File.Exists(filePath))
            {
                byte[] fileData = System.IO.File.ReadAllBytes(filePath);

                Texture2D iconTexture = new(width, height, textureFormat, false, linear);
                iconTexture.LoadImage(fileData);

                return Sprite.Create(iconTexture, new(0, 0, iconTexture.width, iconTexture.height), Vector2.one);
            }

            if (!defaultTexture)
                return null;

            return Sprite.Create(defaultTexture, new(0, 0, defaultTexture.width, -defaultTexture.height), Vector2.one);
        }

        public static void DrawSprite(Rect position, Sprite sprite)
        {
            if (!sprite)
                return;

            Texture2D texture = sprite.texture;
            Rect spriteRect = new(sprite.textureRect.position + sprite.textureRectOffset, sprite.textureRect.size);
            Rect texCoords = new(spriteRect.x / texture.width, spriteRect.y / texture.height, spriteRect.width / texture.width, spriteRect.height / texture.height);

            GUI.DrawTextureWithTexCoords(position, texture, texCoords);
        }

        public static void Swap<T, U>(ref T a, ref U b)
        {
            T c = a;
            a = (T)(object)b;
            b = (U)(object)c;
        }

        public static string PrintNames<T>(IEnumerable<T> list, System.Func<T, string> nameGetter, string emptyMessage = "None", string and = "&")
        {
            StringBuilder items = new();

            if (list.Count() == 2)
            {
                items.Append($"{nameGetter.Invoke(list.ElementAt(0))} {and} {nameGetter.Invoke(list.ElementAt(1))}");
            }
            else if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count(); ++i)
                {
                    string separator = i != list.Count() - 2 ? ", " : $", {and} ";
                    items.Append(nameGetter.Invoke(list.ElementAt(i)) + separator);
                }

                items.Remove(items.Length - 2, 2);
            }
            else
            {
                items.Append(emptyMessage);
            }

            return items.ToString();
        }

        public static void NoOp() { }
    }
}
