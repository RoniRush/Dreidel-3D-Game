namespace A20Ex04Aviram300913910Roni206317455.GameClasses
{
     using System.Collections.Generic;
     using Infrastructure.ObjectModel;
     using Microsoft.Xna.Framework;

     public enum eModelType
     {
          TriangleStripAndTexture,
          TriangleListAndColor,
          TriangleListAndTexture,
          TriangleStripAndColor,
          TriangleListAndColorWithIndex,
          TriangleListAndTextureWithIndex
     }

     public static class Creator3DModels
     {
          public static Model3D CreateModel(eModelType i_ModelType, Game i_Game, List<Vector3> i_Coords, List<Color> i_Colors, params short[] i_IndexArr)
          {
               Model3D model3D = new Model3D(i_Game);
               model3D.VertexFilling = createVertexPositionColor(i_Game, i_Coords, i_Colors);
               createModel(model3D, i_ModelType, i_IndexArr);
               return model3D;
          }

          public static Model3D CreateModel(eModelType i_ModelType, Game i_Game, List<Vector3> i_Coords, List<Vector2> i_TextureMap, string i_TexturePath, params short[] i_IndexArr)
          {
               Model3D model3D = new Model3D(i_Game);
               model3D.VertexFilling = createVertexPositionTexture(i_Game, i_Coords, i_TextureMap, i_TexturePath);
               createModel(model3D, i_ModelType, i_IndexArr);
               return model3D;
          }

          private static void createModel(Model3D i_Model3D, eModelType i_ModelType, params short[] i_IndexArr)
          {
               int numOfVertices = i_Model3D.VertexFilling.NumOfVertices;
               if(i_IndexArr != null)
               {
                    if(i_IndexArr.Length > 0)
                    {
                         numOfVertices = i_IndexArr.Length;
                    }
               }

               addIndexBufferToModelIfNeeded(i_Model3D, i_IndexArr);
               i_Model3D.VerticesPassingType = createVertexPassingType(
                    i_ModelType,
                    numOfVertices);
          }

          private static IVerticesPassingType createVertexPassingType(eModelType i_ModelType, int i_NumOfVertices)
          {
               IVerticesPassingType verticesPassing = null;
               switch (i_ModelType)
               {
                    case eModelType.TriangleListAndColorWithIndex:
                    case eModelType.TriangleListAndTextureWithIndex:
                    case eModelType.TriangleListAndTexture:
                    case eModelType.TriangleListAndColor:
                         verticesPassing = new TriangleListPassing(i_NumOfVertices);
                         break;
                    case eModelType.TriangleStripAndTexture:
                    case eModelType.TriangleStripAndColor:
                         verticesPassing = new TriangleStripPassing(i_NumOfVertices);
                         break;
               }

               return verticesPassing;
          }

          private static void addIndexBufferToModelIfNeeded(Model3D i_Model3D, params short[] i_IndexArr)
          {
               if(i_IndexArr != null)
               {
                    if(i_IndexArr.Length > 0)
                    {
                         i_Model3D.VertexFilling.IsIndexDrawn = true;
                         i_Model3D.VertexFilling.IndexArray = i_IndexArr;
                    }
               }
          }

          private static VertexFilling createVertexPositionColor(Game i_Game, List<Vector3> i_Coords, List<Color> i_Colors)
          {
               Color3DModel color3DModel = new Color3DModel(i_Game, i_Coords, i_Colors);
               return color3DModel;
          }

          private static VertexFilling createVertexPositionTexture(Game i_Game, List<Vector3> i_Coords, List<Vector2> i_TextureMap, string i_TexturePath)
          {
               return new Texture3DModel(i_Game, i_Coords, i_TextureMap, i_TexturePath);
          }
     }
}
