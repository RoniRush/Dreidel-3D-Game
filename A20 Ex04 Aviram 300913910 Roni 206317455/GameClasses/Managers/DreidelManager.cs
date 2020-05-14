namespace A20Ex04Aviram300913910Roni206317455.GameClasses.Managers
{
     using System.Collections.Generic;
     using System.Linq;
     using A20Ex04Aviram300913910Roni206317455.GameClasses.Models;
     using Infrastructure.ObjectModel;
     using Microsoft.Xna.Framework;

     public class DreidelManager : CompositeDrawableComponent<IGameComponent>
     {
          private const int k_NumOfDreidelsFromEachType = 2;
          private const int k_NumOfDreidels = 6;
          private List<Dreidel> m_Dreidels;
          private Vector3[] m_MinDreidlePositionArray;
          private Vector3[] m_MaxDreidlePositionArray;
          private int m_PositionArrIndex;

          public DreidelManager(Game i_Game)
               : base(i_Game)
          {
               m_MinDreidlePositionArray = new Vector3[6];
               m_MaxDreidlePositionArray = new Vector3[6];
               m_Dreidels = new List<Dreidel>(k_NumOfDreidels);
          }

          private void initDreidlePositionArrays()
          {
               float positiveWidth = (Game.GraphicsDevice.Viewport.Width / 20) - 10;
               float positiveHeight = (Game.GraphicsDevice.Viewport.Height / 20) - 7;
               float negativeWidth = -positiveWidth;
               float negativeHeight = -positiveHeight;
               m_MinDreidlePositionArray[0] = new Vector3(negativeWidth, 0, -30);
               m_MinDreidlePositionArray[1] = new Vector3(negativeWidth / 2, 0, -30);
               m_MinDreidlePositionArray[2] = new Vector3(positiveWidth / 2, 0, -30);
               m_MinDreidlePositionArray[3] = new Vector3(negativeWidth, negativeHeight, -30);
               m_MinDreidlePositionArray[4] = new Vector3(negativeWidth / 2, negativeHeight, -30);
               m_MinDreidlePositionArray[5] = new Vector3(positiveWidth / 2, negativeHeight, -30);
               m_MaxDreidlePositionArray[0] = new Vector3(negativeWidth / 2, positiveHeight, 2);
               m_MaxDreidlePositionArray[1] = new Vector3(positiveWidth / 2, positiveHeight, 2);
               m_MaxDreidlePositionArray[2] = new Vector3(positiveWidth, positiveHeight, 2);
               m_MaxDreidlePositionArray[3] = new Vector3(negativeWidth / 2, 0, 2);
               m_MaxDreidlePositionArray[4] = new Vector3(positiveWidth / 2, 0, 2);
               m_MaxDreidlePositionArray[5] = new Vector3(positiveWidth, 0, 2);
          }

          public override void Initialize()
          {
               base.Initialize();
               initDreidlePositionArrays();
               initDreidels();
               addComponents();
          }

          public bool IsRoundOver()
          {
               bool isRoundOver = true;
               foreach(Dreidel dreidel in m_Dreidels)
               {
                    if(dreidel.AngularVelocity != Vector3.Zero)
                    {
                         isRoundOver = false;
                         break;
                    }
               }

               return isRoundOver;
          }

          private void initDreidels()
          {
               createFirstTypeDreidle();
               createSecondTypeDreidle();
               createThirdTypeDreidle();
          }

          private void createThirdTypeDreidle()
          {
               for(int i = 0; i < k_NumOfDreidelsFromEachType; i++)
               {
                    List<Model3D> modelList = new List<Model3D>();
                    short[] indexArray;
                    List<Vector3> bodyCoordinates = Box3DSettings.CreateCoordsForBoxBodyTriangleListWithIndex(-20, 20, -20, 20, -20, 20, out indexArray);
                    List<Vector2> bodyTextureMap = Box3DSettings.GetTextureMapTriangleStrip();
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndTextureWithIndex, Game, bodyCoordinates, bodyTextureMap, @"Textures\DreidelTexture", indexArray));
                    List<Vector3> handleCoordinates = Box3DSettings.CreateCoordsForBoxBodyTriangleListWithIndex(-3, 3, 20, 30, -3, 3, out indexArray);
                    List<Color> handleColors = getColorList(Color.Red, handleCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColorWithIndex, Game, handleCoordinates, handleColors, indexArray));
                    List<Vector3> bodyTopCoordinates = Box3DSettings.CreateCoordsForBoxTopTriangleListWithIndex(-20, 20, 20, -20, 20, out indexArray);
                    List<Color> bodyTopColors = getColorList(Color.LightGray, bodyTopCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColorWithIndex, Game, bodyTopCoordinates, bodyTopColors, indexArray));
                    List<Vector3> handleTopCoordinates = Box3DSettings.CreateCoordsForBoxTopTriangleListWithIndex(-3, 3, 30, -3, 3, out indexArray);
                    List<Color> handleTopColors = getColorList(Color.Red, handleTopCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColorWithIndex, Game, handleTopCoordinates, handleTopColors, indexArray));
                    createPyramidAndAddToModelList(modelList, true);
                    m_Dreidels.Add(new Dreidel(Game, modelList, m_MinDreidlePositionArray[m_PositionArrIndex], m_MaxDreidlePositionArray[m_PositionArrIndex]));
                    m_PositionArrIndex++;
               }
          }

          private void createFirstTypeDreidle()
          {
               for (int i = 0; i < k_NumOfDreidelsFromEachType; i++)
               {
                    List<Model3D> modelList = new List<Model3D>();
                    List<Vector3> bodyCoordinates = Box3DSettings.CreateCoordsForBoxBodyTriangleListWithoutIndex(-20, 20, -20, 20, -20, 20);
                    List<Color> bodyColors = Box3DSettings.CreateColorForBoxBodyTriangleList(Color.Yellow, Color.LawnGreen, Color.Red, Color.Blue);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, bodyCoordinates, bodyColors));
                    List<Vector3> handleCoordinates = Box3DSettings.CreateCoordsForBoxBodyTriangleListWithoutIndex(-3, 3, 20, 30, -3, 3);
                    List<Color> handleColors = getColorList(Color.Yellow, handleCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, handleCoordinates, handleColors));
                    List<Vector3> bodyTopCoordinates = Box3DSettings.CreateCoordsForBoxTopTriangleListWithoutIndex(-20, 20, 20, -20, 20);
                    List<Color> bodyTopColors = getColorList(Color.LightGray, bodyTopCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, bodyTopCoordinates, bodyTopColors));
                    List<Vector3> handleTopCoordinates = Box3DSettings.CreateCoordsForBoxTopTriangleListWithoutIndex(-3, 3, 30, -3, 3);
                    List<Color> handleTopColors = getColorList(Color.Yellow, handleTopCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, handleTopCoordinates, handleTopColors));
                    createLetters(modelList);
                    createPyramidAndAddToModelList(modelList, false);
                    m_Dreidels.Add(new Dreidel(Game, modelList, this.m_MinDreidlePositionArray[m_PositionArrIndex], m_MaxDreidlePositionArray[m_PositionArrIndex]));
                    m_PositionArrIndex++;
               }
          }

          private void createLetters(List<Model3D> i_ModelList)
          {
               List<Vector3> letterBCoordinates = LettersSetting.CreateLetterB();
               List<Color> letterBColors = getColorList(Color.Black, letterBCoordinates.Count);
               i_ModelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, letterBCoordinates, letterBColors));
               List<Vector3> letterDCoordinates = LettersSetting.CreateLetterD();
               List<Color> letterDColors = getColorList(Color.Black, letterDCoordinates.Count);
               i_ModelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, letterDCoordinates, letterDColors));
               List<Vector3> letterPCoordinates = LettersSetting.CreateLetterP();
               List<Color> letterPColors = getColorList(Color.Black, letterPCoordinates.Count);
               i_ModelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, letterPCoordinates, letterPColors));
               List<Vector3> letterVCoordinates = LettersSetting.CreateLetterV();
               List<Color> letterVColors = getColorList(Color.Black, letterVCoordinates.Count);
               i_ModelList.Add(Creator3DModels.CreateModel(eModelType.TriangleListAndColor, Game, letterVCoordinates, letterVColors));
          }

          private void createSecondTypeDreidle()
          {
               for (int i = 0; i < k_NumOfDreidelsFromEachType; i++)
               {
                    List<Model3D> modelList = new List<Model3D>();
                    List<Vector3> bodyCoordinates = Box3DSettings.CreateCoordsForBoxBodyTriangleStrip(-20, 20, -20, 20, -20, 20);
                    List<Vector2> bodyTextureMap = Box3DSettings.GetTextureMapTriangleStrip();
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleStripAndTexture, Game, bodyCoordinates, bodyTextureMap, @"Textures\DreidelTexture"));
                    List<Vector3> handleCoordinates = Box3DSettings.CreateCoordsForBoxBodyTriangleStrip(-3, 3, 20, 30, -3, 3);
                    List<Color> handleColors = getColorList(Color.Blue, handleCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleStripAndColor, Game, handleCoordinates, handleColors));
                    createPyramidAndAddToModelList(modelList, false);
                    List<Vector3> bodyTopCoordinates = Box3DSettings.CreateCoordsForBoxTopTriangleStrip(-20, 20, 20, -20, 20);
                    List<Color> bodyTopColors = getColorList(Color.LightGray, bodyTopCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleStripAndColor, Game, bodyTopCoordinates, bodyTopColors));
                    List<Vector3> handleTopCoordinates = Box3DSettings.CreateCoordsForBoxTopTriangleStrip(-3, 3, 30, -3, 3);
                    List<Color> handleTopColors = getColorList(Color.Blue, handleTopCoordinates.Count);
                    modelList.Add(Creator3DModels.CreateModel(eModelType.TriangleStripAndColor, Game, handleTopCoordinates, handleTopColors));
                    m_Dreidels.Add(new Dreidel(Game, modelList, this.m_MinDreidlePositionArray[m_PositionArrIndex], m_MaxDreidlePositionArray[m_PositionArrIndex]));
                    m_PositionArrIndex++;
               }
          }

          private void createPyramidAndAddToModelList(List<Model3D> i_ModelList, bool i_IsWithIndex)
          {
               short[] indexArray = null;
               List<Vector3> pyramidCoordinates;
               if(i_IsWithIndex)
               {
                    pyramidCoordinates = Pyramid3DSettings.CreateCoordsForPyramidWithIndex(
                         -20,
                         20,
                         -35,
                         -20,
                         -20,
                         20,
                         out indexArray);
               }
               else
               {
                    pyramidCoordinates = Pyramid3DSettings.CreateCoordsForPyramidWithoutIndex(-20, 20, -35, -20, -20, 20);
               }

               List<Color> pyramidColors = getColorList(Color.Gray, pyramidCoordinates.Count);
               i_ModelList.Add(
                    Creator3DModels.CreateModel(
                         eModelType.TriangleListAndColor,
                         Game,
                         pyramidCoordinates,
                         pyramidColors, 
                         indexArray));
          }

          private List<Color> getColorList(Color i_Color, int i_Size)
          {
               List<Color> colorList = new List<Color>();
               colorList.AddRange(Enumerable.Repeat(i_Color, i_Size));
               return colorList;
          }

          private void addComponents()
          {
               foreach(Dreidel dreidel in m_Dreidels)
               {
                    Add(dreidel);
               }
          }

          public void SetDreidelsAngularVelocity()
          {
               foreach(Dreidel dreidel in m_Dreidels)
               {
                    dreidel.SetDreidelsAngularVelocity();
               }
          }

          public int GetRoundResults(string i_Bet)
          {
               int sumOfSuccessfulHits = 0;
               foreach(Dreidel dreidel in m_Dreidels)
               {
                    if(dreidel.WinningLetter.Equals(i_Bet))
                    {
                         sumOfSuccessfulHits++;
                    }
               }

               return sumOfSuccessfulHits;
          }
     }
}
