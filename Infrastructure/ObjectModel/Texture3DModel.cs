namespace Infrastructure.ObjectModel
{
     using System.Collections.Generic;
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Graphics;

     public class Texture3DModel : VertexFilling
     {
          private VertexPositionTexture[] m_Vertices;
          private string m_AssetName;
          private Texture2D m_Texture;

          public Texture3DModel(Game i_Game, List<Vector3> i_VertexCoordinates, List<Vector2> i_TextureMapping, string i_AssetName)
               : base(i_Game)
          {
               m_AssetName = i_AssetName;
               initVerticesArray(i_VertexCoordinates, i_TextureMapping);
               NumOfVertices = i_VertexCoordinates.Count;
          }

          private void initVerticesArray(List<Vector3> i_VertexCoordinates, List<Vector2> i_TextureMapping)
          {
               m_Vertices = new VertexPositionTexture[i_VertexCoordinates.Count];
               for (int i = 0; i < i_VertexCoordinates.Count; i++)
               {
                     m_Vertices[i] = new VertexPositionTexture(i_VertexCoordinates[i], i_TextureMapping[i]);
               }
          }

          public override void LoadVerticesAndBuffer(BasicEffect i_BasicEffect)
          {
               m_Texture = Game.Content.Load<Texture2D>(m_AssetName);
               i_BasicEffect.Texture = m_Texture;
               i_BasicEffect.TextureEnabled = true;
               VertexBuffer = new VertexBuffer(Game.GraphicsDevice, typeof(VertexPositionTexture), m_Vertices.Length, BufferUsage.WriteOnly);
               VertexBuffer.SetData(m_Vertices, 0, m_Vertices.Length);
               SetIndexBuffer();
          }
     }
}
