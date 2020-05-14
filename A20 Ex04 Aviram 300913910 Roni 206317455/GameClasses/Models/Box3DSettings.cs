namespace A20Ex04Aviram300913910Roni206317455.GameClasses.Models
{
     using System.Collections.Generic;
     using System.Linq;
     using Microsoft.Xna.Framework;

     public static class Box3DSettings
     {
          public static List<Vector3> CreateCoordsForBoxBodyTriangleStrip(float i_XMin, float i_XMax, float i_YMin, float i_YMax, float i_ZMin, float i_ZMax)
          {
               List<Vector3> coordinates = new List<Vector3>
                                                {
                                                     new Vector3(i_XMin, i_YMin, i_ZMax),
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMin, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMin, i_ZMin),
                                                     new Vector3(i_XMax, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMin, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMin, i_ZMax),
                                                     new Vector3(i_XMin, i_YMax, i_ZMax)
                                                };
               return coordinates;
          }

          public static List<Vector3[]> CreateDreidleSideCoords(float i_XMin, float i_XMax, float i_YMin, float i_YMax, float i_ZMin, float i_ZMax)
          {
               List<Vector3[]> dreidleCoords = new List<Vector3[]>();
               Vector3[] dreidleSideCoords1 = new Vector3[3];
               dreidleSideCoords1[0] = new Vector3(i_XMin, i_YMin, i_ZMax);
               dreidleSideCoords1[1] = new Vector3(i_XMin, i_YMax, i_ZMax);
               dreidleSideCoords1[2] = new Vector3(i_XMax, i_YMin, i_ZMax);
               dreidleCoords.Add(dreidleSideCoords1);
               Vector3[] dreidleSideCoords2 = new Vector3[3];
               dreidleSideCoords2[0] = new Vector3(i_XMax, i_YMax, i_ZMin);
               dreidleSideCoords2[1] = new Vector3(i_XMax, i_YMin, i_ZMin);
               dreidleSideCoords2[2] = new Vector3(i_XMax, i_YMax, i_ZMax);
               dreidleCoords.Add(dreidleSideCoords2);
               Vector3[] dreidleSideCoords3 = new Vector3[3];
               dreidleSideCoords3[0] = new Vector3(i_XMax, i_YMax, i_ZMin);
               dreidleSideCoords3[1] = new Vector3(i_XMin, i_YMax, i_ZMin);
               dreidleSideCoords3[2] = new Vector3(i_XMax, i_YMin, i_ZMin);
               dreidleCoords.Add(dreidleSideCoords3);
               Vector3[] dreidleSideCoords4 = new Vector3[3];
               dreidleSideCoords4[0] = new Vector3(i_XMin, i_YMax, i_ZMax);
               dreidleSideCoords4[1] = new Vector3(i_XMin, i_YMin, i_ZMax);
               dreidleSideCoords4[2] = new Vector3(i_XMin, i_YMax, i_ZMin);
               dreidleCoords.Add(dreidleSideCoords4);
               return dreidleCoords;
          }

          public static List<Vector3> CreateCoordsForBoxBodyTriangleListWithIndex(float i_XMin, float i_XMax, float i_YMin, float i_YMax, float i_ZMin, float i_ZMax, out short[] o_IndexBuffer)
          {
               List<Vector3> coordinates = CreateCoordsForBoxBodyTriangleStrip(i_XMin, i_XMax, i_YMin, i_YMax, i_ZMin, i_ZMax);
               o_IndexBuffer = new short[24];
               o_IndexBuffer[0] = 0;
               o_IndexBuffer[1] = 1;
               o_IndexBuffer[2] = 2;
               o_IndexBuffer[3] = 2;
               o_IndexBuffer[4] = 1;
               o_IndexBuffer[5] = 3;
               o_IndexBuffer[6] = 2;
               o_IndexBuffer[7] = 3;
               o_IndexBuffer[8] = 4;
               o_IndexBuffer[9] = 4;
               o_IndexBuffer[10] = 3;
               o_IndexBuffer[11] = 5;
               o_IndexBuffer[12] = 4;
               o_IndexBuffer[13] = 5;
               o_IndexBuffer[14] = 6;
               o_IndexBuffer[15] = 6;
               o_IndexBuffer[16] = 5;
               o_IndexBuffer[17] = 7;
               o_IndexBuffer[18] = 6;
               o_IndexBuffer[19] = 7;
               o_IndexBuffer[20] = 8;
               o_IndexBuffer[21] = 8;
               o_IndexBuffer[22] = 7;
               o_IndexBuffer[23] = 9;
               return coordinates;
          }

          public static List<Vector3> CreateCoordsForBoxBodyTriangleListWithoutIndex(float i_XMin, float i_XMax, float i_YMin, float i_YMax, float i_ZMin, float i_ZMax)
          {
               List<Vector3> coordinates = new List<Vector3>
                                                {
                                                     new Vector3(i_XMin, i_YMin, i_ZMax),
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMin, i_ZMax),
                                                     new Vector3(i_XMax, i_YMin, i_ZMax),
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMin),
                                                     new Vector3(i_XMax, i_YMin, i_ZMin),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMin, i_ZMin),
                                                     new Vector3(i_XMax, i_YMin, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(i_XMax, i_YMin, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMin, i_ZMin),
                                                     new Vector3(i_XMax, i_YMin, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(i_XMin, i_YMin, i_ZMax),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMin, i_ZMax),
                                                     new Vector3(i_XMin, i_YMin, i_ZMin)
                                                };
               return coordinates;
          }

          public static List<Vector3> CreateCoordsForBoxTopTriangleStrip(float i_XMin, float i_XMax, float i_Y, float i_ZMin, float i_ZMax)
          {
               List<Vector3> coordinates = new List<Vector3>
                                                {
                                                     new Vector3(i_XMin, i_Y, i_ZMax),
                                                     new Vector3(i_XMin, i_Y, i_ZMin),
                                                     new Vector3(i_XMax, i_Y, i_ZMax),
                                                     new Vector3(i_XMax, i_Y, i_ZMin)
                                                };
               return coordinates;
          }

          public static List<Vector3> CreateCoordsForBoxTopTriangleListWithoutIndex(float i_XMin, float i_XMax, float i_Y, float i_ZMin, float i_ZMax)
          {
               List<Vector3> coordinates = new List<Vector3>
                                                {
                                                     new Vector3(i_XMax, i_Y, i_ZMin),
                                                     new Vector3(i_XMax, i_Y, i_ZMax),
                                                     new Vector3(i_XMin, i_Y, i_ZMin),
                                                     new Vector3(i_XMin, i_Y, i_ZMin),
                                                     new Vector3(i_XMax, i_Y, i_ZMax),
                                                     new Vector3(i_XMin, i_Y, i_ZMax)
                                                };
               return coordinates;
          }

          public static List<Vector3> CreateCoordsForBoxTopTriangleListWithIndex(float i_XMin, float i_XMax, float i_Y, float i_ZMin, float i_ZMax, out short[] i_IndexArr)
          {
               List<Vector3> coordinates =
                    CreateCoordsForBoxTopTriangleStrip(i_XMin, i_XMax, i_Y, i_ZMin, i_ZMax);
               i_IndexArr = new short[6];
               i_IndexArr[0] = 0;
               i_IndexArr[1] = 1;
               i_IndexArr[2] = 2;
               i_IndexArr[3] = 1;
               i_IndexArr[4] = 3;
               i_IndexArr[5] = 2;
               return coordinates;
          }

          public static List<Vector2> GetTextureMapTriangleStrip()
          {
               List<Vector2> textureMap = new List<Vector2>
                                               {
                                                    new Vector2(0, 1),
                                                    new Vector2(0, 0),
                                                    new Vector2(0.25f, 1),
                                                    new Vector2(0.25f, 0),
                                                    new Vector2(0.5f, 1),
                                                    new Vector2(0.5f, 0),
                                                    new Vector2(0.75f, 1),
                                                    new Vector2(0.75f, 0),
                                                    new Vector2(1, 1),
                                                    new Vector2(1, 0)
                                               };
               return textureMap;
          }

          public static List<Color> CreateColorForBoxBodyTriangleList(params Color[] i_Colors)
          {
               List<Color> color = new List<Color>();
               for(int i = 0; i < i_Colors.Length; i++)
               {
                    color.AddRange(Enumerable.Repeat(i_Colors[i], 6));
               }

               return color;
          }
     }
}
