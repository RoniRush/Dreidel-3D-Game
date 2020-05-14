namespace Infrastructure.ObjectModel
{
     using Infrastructure.Services;
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Graphics;

     public class Model3D : DrawableGameComponent
     {
          public Model3D(Game i_Game)
               : base(i_Game)
          {
               Scales = new Vector3(0.1f);
          }

          public VertexFilling VertexFilling { get; set; }

          public int BaseVertex { get; set; }

          public IVerticesPassingType VerticesPassingType { get; set; }

          public int InitialDrawingPosition { get; set; }

          private Camera m_Camera;

          public RasterizerState RasterizerState { get; set; }

          public BasicEffect BasicEffect { get; set; }

          public Matrix WorldMatrix { get; set; } = Matrix.Identity;

          public Vector3 Position { get; set; }

          public Vector3 Velocity { get; set; }

          public Vector3 Rotations { get; set; }

          public Vector3 AngularVelocity { get; set; }

          public Vector3 Scales { get; set; }

          protected override void LoadContent()
          {
               RasterizerState = new RasterizerState();
               BasicEffect = new BasicEffect(this.GraphicsDevice);
               m_Camera = Game.Services.GetService(typeof(Camera)) as Camera ?? new Camera(Game);
               RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
               VertexFilling.LoadVerticesAndBuffer(BasicEffect);
               base.LoadContent();
          }

          public override void Update(GameTime gameTime)
          {
               Rotations += -AngularVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
               buildWorldMatrix();
               base.Update(gameTime);
          }

          private void buildWorldMatrix()
          {
               WorldMatrix = Matrix.Identity * Matrix.CreateScale(Scales) * Matrix.CreateRotationX(Rotations.X)
                             * Matrix.CreateRotationY(Rotations.Y) * Matrix.CreateRotationZ(Rotations.Z)
                             * Matrix.CreateTranslation(Position);
          }

          public override void Draw(GameTime gameTime)
          {
               BasicEffect.World = WorldMatrix;
               BasicEffect.View = m_Camera.ViewMatrix;
               BasicEffect.Projection = m_Camera.ProjectionMatrix;
               BasicEffect.GraphicsDevice.RasterizerState = RasterizerState;
               BasicEffect.GraphicsDevice.SetVertexBuffer(VertexFilling.VertexBuffer);
               if (!VertexFilling.IsIndexDrawn)
               {
                    foreach (EffectPass pass in BasicEffect.CurrentTechnique.Passes)
                    {
                         pass.Apply();
                         BasicEffect.GraphicsDevice.DrawPrimitives(VerticesPassingType.PrimitiveType, InitialDrawingPosition, VerticesPassingType.PrimitiveCount);
                    }
               }
               else
               {
                    BasicEffect.GraphicsDevice.Indices = VertexFilling.IndexBuffer;
                    foreach (EffectPass pass in BasicEffect.CurrentTechnique.Passes)
                    {
                         pass.Apply();
                         BasicEffect.GraphicsDevice.DrawIndexedPrimitives(VerticesPassingType.PrimitiveType, BaseVertex, InitialDrawingPosition, VerticesPassingType.PrimitiveCount);
                    }
               }
          }
     }
}
