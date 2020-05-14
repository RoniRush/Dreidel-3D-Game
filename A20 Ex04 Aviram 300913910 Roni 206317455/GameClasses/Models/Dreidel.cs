namespace A20Ex04Aviram300913910Roni206317455.GameClasses.Models
{
     using System;
     using System.Collections.Generic;
     using Infrastructure.ObjectModel;
     using Microsoft.Xna.Framework;

     public class Dreidel : CompositeDrawableComponent<IGameComponent>
     {
          private static readonly Random sr_RandomGenerator = new Random();

          public List<Model3D> Models { get; set; }

          public Vector3 AngularVelocity { get; set; }

          public Vector3 Position { get; set; }

          public string WinningLetter { get; set; }

          public float AngularVelocityFactor { get; set; }

          private bool m_StartRound;

          public Dreidel(Game i_Game, List<Model3D> i_Models, Vector3 i_MinPosition, Vector3 i_MaxPosition)
               : base(i_Game)
          {
               Models = i_Models;
               initPosition(i_MinPosition, i_MaxPosition);
               addComponents();
               AngularVelocityFactor = 0.3f;
          }

          private void initPosition(Vector3 i_MinPosition, Vector3 i_MaxPosition)
          {
               float[] positionVector = new float[3];
               positionVector[0] = randomNum(i_MinPosition.X, i_MaxPosition.X);
               positionVector[1] = randomNum(i_MinPosition.Y, i_MaxPosition.Y);
               positionVector[2] = randomNum(i_MinPosition.Z, i_MaxPosition.Z);
               Position = new Vector3(positionVector[0], positionVector[1], positionVector[2]);
               foreach (Model3D model in Models)
               {
                    model.Position = Position;
               }
          }

          private float randomNum(float i_MinValue, float i_MaxValue)
          {
               return sr_RandomGenerator.Next((int)i_MinValue, (int)i_MaxValue);
          }

          private void addComponents()
          {
               foreach(Model3D model in Models)
               {
                    Add(model);
               }
          }

          public void SetDreidelsAngularVelocity()
          {
               float yAngularVelocity;
               do
               {
                    yAngularVelocity = (float)sr_RandomGenerator.NextDouble();
               }
               while(yAngularVelocity < 0.3 || yAngularVelocity > 0.7);
               AngularVelocity = new Vector3(0, yAngularVelocity * 5, 0);
          }

          public override void Update(GameTime i_GameTime)
          {
               if (AngularVelocity.X > 0 || AngularVelocity.Y > 0 || AngularVelocity.Z > 0)
               {
                    m_StartRound = true;
                    float newAngularVelocity = (float)(AngularVelocityFactor * i_GameTime.ElapsedGameTime.TotalSeconds); 
                    AngularVelocity -= new Vector3(0, newAngularVelocity, 0);
               }
               else
               {
                    if (m_StartRound)
                    {
                         AngularVelocity = Vector3.Zero;
                         findWinningLetter();
                         m_StartRound = false;
                    }
               }

               foreach(Model3D model3D in Models)
               {
                    model3D.AngularVelocity = AngularVelocity;
               }

               base.Update(i_GameTime);
          }

          private void findWinningLetter()
          {
               float factor = 0;
               Model3D model = Models[0];
               float rotation = model.Rotations.Y;
               while (rotation < -MathHelper.TwoPi)
               {
                    rotation += MathHelper.TwoPi;
               }

               if (rotation >= -MathHelper.TwoPi && rotation < -(MathHelper.Pi * 1.5f))
               {
                    factor = assignFactorAndLetter(rotation, -MathHelper.TwoPi, -(MathHelper.Pi * 1.5f), "B", "P");
               }
               else if (rotation >= -(MathHelper.Pi * 1.5f) && rotation < -MathHelper.Pi)
               {
                    factor = assignFactorAndLetter(rotation, -(MathHelper.Pi * 1.5f), -MathHelper.Pi, "P", "V");
               }
               else if (rotation >= -MathHelper.Pi && rotation < -MathHelper.PiOver2)
               {
                    factor = assignFactorAndLetter(rotation, -MathHelper.Pi, -MathHelper.PiOver2, "V", "D");
               }
               else if (rotation >= -MathHelper.PiOver2 && rotation < 0)
               {
                    factor = assignFactorAndLetter(rotation, -MathHelper.PiOver2, 0, "D", "B");
               }

               foreach (Model3D model3D in Models)
               {
                    model3D.Rotations = new Vector3(0, factor, 0);
               }
          }

          private float assignFactorAndLetter(float i_CurrentYRotation, float i_LowerBound, float i_UpperBound, string i_LowerBoundLetter, string i_UpperBoundLetter)
          {
               float innerFactor1 = Math.Abs(i_CurrentYRotation - i_LowerBound);
               float innerFactor2 = Math.Abs(i_CurrentYRotation - i_UpperBound);
               float factor = i_UpperBound;
               WinningLetter = i_UpperBoundLetter;
               if (innerFactor1 < innerFactor2)
               {
                    factor = i_LowerBound;
                    WinningLetter = i_LowerBoundLetter;
               }

               return factor;
          }
     }
}
