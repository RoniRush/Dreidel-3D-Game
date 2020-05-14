namespace Infrastructure.ObjectModel
{
     using Microsoft.Xna.Framework.Graphics;

     public interface IVerticesPassingType
     {
          PrimitiveType PrimitiveType { get; }

          int PrimitiveCount { get; set; }
     }
}
