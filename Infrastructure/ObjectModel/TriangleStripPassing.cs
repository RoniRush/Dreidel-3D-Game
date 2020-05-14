namespace Infrastructure.ObjectModel
{
     using Microsoft.Xna.Framework.Graphics;

     public class TriangleStripPassing : IVerticesPassingType
     {
          public PrimitiveType PrimitiveType { get; }

          public int PrimitiveCount { get; set; }

          public TriangleStripPassing(int i_VerticesListSize)
          {
               PrimitiveType = PrimitiveType.TriangleStrip;
               PrimitiveCount = i_VerticesListSize - 2;
          }
     }
}
