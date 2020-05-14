namespace A20Ex04Aviram300913910Roni206317455.GameClasses.Managers
{
     using Infrastructure.Managers;
     using Infrastructure.ObjectModel;
     using Infrastructure.ServiceInterfaces;
     using Microsoft.Xna.Framework;
     using Microsoft.Xna.Framework.Input;

     public class GameManager : CompositeDrawableComponent<IGameComponent>
     {
          private DreidelManager m_DreidelManager;
          private InputManager m_InputManager;
          private bool m_IsInRound;
          private int m_Score;
          private string m_Bet;

          public string Title { get; set; }

          public GameManager(Game i_Game)
               : base(i_Game)
          {
               m_DreidelManager = new DreidelManager(i_Game);
               addComponents();
               m_Bet = string.Empty;
               m_Score = 0;
          }

          private void addComponents()
          {
               Add(m_DreidelManager);
          }

          public override void Initialize()
          {
               base.Initialize();
               m_InputManager = (Game.Services.GetService(typeof(IInputManager)) as IInputManager) as InputManager;
          }

          public override void Update(GameTime gameTime)
          {
               Title = string.Format(@"Score: {0} Bet: {1}", m_Score, m_Bet);
               if (m_InputManager.KeyboardState.IsKeyDown(Keys.Space)
                  && m_InputManager.PrevKeyboardState.IsKeyUp(Keys.Space) 
                  && m_Bet != string.Empty
                  && !m_IsInRound)
               {
                    m_IsInRound = true;
                    m_DreidelManager.SetDreidelsAngularVelocity();
               }

               getBet();
               if(m_IsInRound)
               {
                    if(m_DreidelManager.IsRoundOver())
                    {
                         m_Score += m_DreidelManager.GetRoundResults(m_Bet);
                         m_IsInRound = false;
                         m_Bet = string.Empty;
                    }
               }

               base.Update(gameTime);
          }

          private void getBet()
          {
               if (m_InputManager.KeyboardState.IsKeyDown(Keys.B)
                   && m_InputManager.PrevKeyboardState.IsKeyUp(Keys.B)
                   && !m_IsInRound)
               {
                    m_Bet = "B";
               }

               if (m_InputManager.KeyboardState.IsKeyDown(Keys.D)
                   && m_InputManager.PrevKeyboardState.IsKeyUp(Keys.D)
                   && !m_IsInRound)
               {
                    m_Bet = "D";
               }

               if (m_InputManager.KeyboardState.IsKeyDown(Keys.V)
                   && m_InputManager.PrevKeyboardState.IsKeyUp(Keys.V)
                   && !m_IsInRound)
               {
                    m_Bet = "V";
               }

               if (m_InputManager.KeyboardState.IsKeyDown(Keys.P)
                   && m_InputManager.PrevKeyboardState.IsKeyUp(Keys.P)
                   && !m_IsInRound)
               {
                    m_Bet = "P";
               }
          }
     }
}
