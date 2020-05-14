namespace Infrastructure.ObjectModel
{
     using Microsoft.Xna.Framework.Graphics;

     public class TriangleListPassing : IVerticesPassingType
     {
          public PrimitiveType PrimitiveType { get; }

          public int PrimitiveCount { get; set; }

          public TriangleListPassing(int i_VerticesListSize)
          {
               PrimitiveType = PrimitiveType.TriangleList;
               PrimitiveCount = i_VerticesListSize / 3;
          }
     }
}
