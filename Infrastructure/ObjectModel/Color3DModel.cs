namespace Infrastructure.ObjectModel
{
     using System.Collections.Generic;
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Graphics;

     public class Color3DModel : VertexFilling
     {
          private VertexPositionColor[] m_Vertices;

          public Color3DModel(Game i_Game, List<Vector3> i_VertexCoordinates, List<Color> i_VertexColors)
               : base(i_Game)
          {
               initVerticesArray(i_VertexCoordinates, i_VertexColors);
               NumOfVertices = i_VertexCoordinates.Count;
          }

          private void initVerticesArray(List<Vector3> i_VertexCoordinates, List<Color> i_VertexColors)
          {
               m_Vertices = new VertexPositionColor[i_VertexCoordinates.Count];
               for(int i = 0; i < i_VertexCoordinates.Count; i++)
               {
                   m_Vertices[i] = m_Vertices[i] = new VertexPositionColor(i_VertexCoordinates[i], i_VertexColors[i]);
               }
          }

          public override void LoadVerticesAndBuffer(BasicEffect i_BasicEffect)
          {
               i_BasicEffect.VertexColorEnabled = true;
               VertexBuffer = new VertexBuffer(
                    Game.GraphicsDevice,
                    typeof(VertexPositionColor),
                    m_Vertices.Length,
                    BufferUsage.WriteOnly);
               VertexBuffer.SetData(m_Vertices, 0, m_Vertices.Length);
               SetIndexBuffer();
          }
     }
}