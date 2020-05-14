namespace Infrastructure.ObjectModel
{
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Graphics;

     public abstract class VertexFilling
     {
          public int NumOfVertices { get; set; }

          public IndexBuffer IndexBuffer { get; set; }

          public short[] IndexArray { get; set; }

          public bool IsIndexDrawn { get; set; }

          public VertexBuffer VertexBuffer { get; set; }

          protected Game Game { get; set; }

          public abstract void LoadVerticesAndBuffer(BasicEffect i_BasicEffect);

          protected VertexFilling(Game i_Game)
          {
               Game = i_Game;
          }

          protected void SetIndexBuffer()
          {
               if(IsIndexDrawn)
               {
                    IndexBuffer = new IndexBuffer(
                         Game.GraphicsDevice,
                         typeof(short),
                         IndexArray.Length,
                         BufferUsage.WriteOnly);
                    IndexBuffer.SetData(IndexArray);
               }
          }
     }
}
