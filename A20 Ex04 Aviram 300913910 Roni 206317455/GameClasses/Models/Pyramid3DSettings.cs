namespace A20Ex04Aviram300913910Roni206317455.GameClasses.Models
{
     using System.Collections.Generic;
     using Microsoft.Xna.Framework;

     public static class Pyramid3DSettings
     {
          public static List<Vector3> CreateCoordsForPyramidWithoutIndex(float i_XMin, float i_XMax, float i_YMin, float i_YMax, float i_ZMin, float i_ZMax)
          {
               List<Vector3> coordinates = new List<Vector3>
                                                {
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(0, i_YMin, 0),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMin),
                                                     new Vector3(0, i_YMin, 0),
                                                     new Vector3(i_XMax, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(0, i_YMin, 0),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(0, i_YMin, 0)
                                                };
               return coordinates;
          }

          public static List<Vector3> CreateCoordsForPyramidWithIndex(float i_XMin, float i_XMax, float i_YMin, float i_YMax, float i_ZMin, float i_ZMax, out short[] o_IndexArr)
          {
               List<Vector3> coordinates = new List<Vector3>
                                                {
                                                     new Vector3(i_XMin, i_YMax, i_ZMax),
                                                     new Vector3(i_XMax, i_YMax, i_ZMax),
                                                     new Vector3(0, i_YMin, 0),
                                                     new Vector3(i_XMax, i_YMax, i_ZMin),
                                                     new Vector3(i_XMin, i_YMax, i_ZMin),
                                                };
               o_IndexArr = new short[12];
               o_IndexArr[0] = 0;
               o_IndexArr[1] = 1;
               o_IndexArr[2] = 2;
               o_IndexArr[3] = 4;
               o_IndexArr[4] = 0;
               o_IndexArr[5] = 2;
               o_IndexArr[6] = 3;
               o_IndexArr[7] = 4;
               o_IndexArr[8] = 2;
               o_IndexArr[9] = 1;
               o_IndexArr[10] = 3;
               o_IndexArr[11] = 2;
               return coordinates;
          }
     }
}
