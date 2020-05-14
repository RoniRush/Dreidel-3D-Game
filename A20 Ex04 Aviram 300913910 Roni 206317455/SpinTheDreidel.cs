namespace A20Ex04Aviram300913910Roni206317455
{
     using A20Ex04Aviram300913910Roni206317455.GameClasses.Managers;
     using Infrastructure.Managers;
     using Infrastructure.Services;
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Input;

     /// <summary>
     /// This is the main type for your game.
     /// </summary>
     public class SpinTheDreidel : Game
     {
          GraphicsDeviceManager graphics;
          private GameManager m_GameManager;

          public SpinTheDreidel()
          {
               graphics = new GraphicsDeviceManager(this);
               Content.RootDirectory = "Content";
               InputManager inputManager = new InputManager(this);
               Camera camera = new Camera(this);
               m_GameManager = new GameManager(this);
               Components.Add(m_GameManager);
          }

          protected override void Update(GameTime gameTime)
          {
               if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                  || Keyboard.GetState().IsKeyDown(Keys.Escape))
               {
                    Exit();
               }

               Window.Title = m_GameManager.Title;
               base.Update(gameTime);
          }

          protected override void Draw(GameTime gameTime)
          {
               GraphicsDevice.Clear(Color.White);
               base.Draw(gameTime);
          }
     }
}
