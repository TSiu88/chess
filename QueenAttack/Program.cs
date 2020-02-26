using System;
using Chess;
class Program
{
  public static Board board = new Board();
  public static void PrintBoard()
  {
    for (int row = 0; row < 8; row++)
    {
      int rowNumber = 8 - row;
      Console.Write("[" + rowNumber + "]\t");
      for(int col = 0; col < 8; col++) {
        string name;
        if(board.spaces[col][row].Piece == null) {
          name = "  ";
        } else {
          name = board.spaces[col][row].Piece.Name;
        }
        
          Console.Write("[" + name + "]\t");
      }
     Console.WriteLine();
    }
    Console.WriteLine("\t[ A ]\t[ B ]\t[ C ]\t[ D ]\t[ E ]\t[ F ]\t[ G ]\t[ H ]\t");
  }
  public static int[] GetCoordinates(string coordinates) {
    char[] xAndY =  coordinates.ToCharArray();
    Console.WriteLine(xAndY.ToString());
    char xAsLetter = xAndY[0];
    char yAsChar = xAndY[1];
    Console.WriteLine(xAsLetter);
    int xAsNumber;
    int correctYNumber;
    switch(xAsLetter) {
      case 'A':
      xAsNumber = 0;
      break;
      case 'B':
      xAsNumber = 1;
      break;
      case 'C':
      xAsNumber = 2;
      break;
      case 'D':
      xAsNumber = 3;
      break;
      case 'E':
      xAsNumber = 4;
      break;
      case 'F':
      xAsNumber = 5;
      break;
      case 'G':
      xAsNumber = 6;
      break;
      case 'H':
      xAsNumber = 7;
      break;
      default:
      xAsNumber = -1;
      break;
    }
    switch(yAsChar) {
      case '8':
      correctYNumber = 0;
      break;
      case '7':
      correctYNumber = 1;
      break;
      case '6':
      correctYNumber = 2;
      break;
      case '5':
      correctYNumber = 3;
      break;
      case '4':
      correctYNumber = 4;
      break;
      case '3':
      correctYNumber = 5;
      break;
      case '2':
      correctYNumber = 6;
      break;
      case '1':
      correctYNumber = 7;
      break;
      default:
      correctYNumber = -1;
      break;
    }
    Console.WriteLine(xAsNumber);
    Console.WriteLine(correctYNumber);
    return new int [] {xAsNumber, correctYNumber};
  }
  public static void Turn() {
    Console.WriteLine(board.Color + "'s turn");
    Console.WriteLine("Select a piece. Please enter x and y coordinates in the format X,Y Ex: A,2");
    string coordinates = Console.ReadLine();
    Console.WriteLine(coordinates);
    int[] coords = GetCoordinates(coordinates);
    
    bool canSelectPiece = board.SelectPiece(coords[0], coords[1]);
    if(canSelectPiece) {
      Console.WriteLine("Move or attack with " + board.currentPiece.Name);
      Console.WriteLine("Enter x and y coordinates to move/attack with piece.");
      string movementCoordinates = Console.ReadLine();
      int[] movementCoords = GetCoordinates(movementCoordinates);
      bool able = board.CheckViable(movementCoords[0], movementCoords[1]);
      if(able) {
        board.Move(movementCoords[0], movementCoords[1]);
        board.ChangePlayer();
        PrintBoard();
        Turn();
      } else {
        Console.WriteLine(board.currentPiece + " can't move there. Try again.");
        Turn();
      }
    }
  }
  static void SelectPiece(int? x, int y)
  {
    // select grid spot --> selects piece in this spot IFF piece exists
    Console.WriteLine("Enter the Column (x coordinate) of the piece you want to select");
    string pieceXString = Console.ReadLine();
    int pieceX = int.Parse(pieceXString);
    Console.WriteLine("Enter the Row (y coordinate) of the piece you want to select");
    string pieceYString = Console.ReadLine();
    int pieceY = int.Parse(pieceYString);
    // if (board.SelectPiece(pieceX, pieceY)) // if piece == null, what happens? wrong color?
    // {
    //   //piece is selected
    //   // do we need to return the piece?
    // }
    // else 
    // {
    //   Console.WriteLine("You do not have a piece in this space. Would you like to select another space? ['Y' for yes, 'enter' for no]");
    //   string attemptAnswer = Console.ReadLine();
    //   if (attemptAnswer == "y" || attemptAnswer == "Y")
    //   {
    //     SelectPiece();
    //   }
    // }
  }
  static void Main()
  {
    board.InitialChessSetup();
    PrintBoard();
    Turn();
    //PrintBoard();
    // Console.ReadLine();

    //If player is white, user can select white pieces
    //board uses selectPiece, current Piece = 
  //  Console.WriteLine("Determine if a queen can attack another chess piece.");
  //  Console.WriteLine("Enter coordinates for the queen.");
  //  Console.WriteLine("Enter x coordinate.");
  //  string queenXCoord = Console.ReadLine();
  //  int queenX = int.Parse(queenXCoord);
  //  Console.WriteLine("Enter y coordinate.");
  //  string queenYCoord = Console.ReadLine();
  //  int queenY = int.Parse(queenYCoord);
  //  Queen q = new Queen(queenX, queenY);
  //  Console.WriteLine("Enter coordinates for the other chess piece.");
  //  Console.WriteLine("Enter x coordinate.");
  //  string pieceXCoord = Console.ReadLine();
  //  int pieceX = int.Parse(pieceXCoord);
  //  Console.WriteLine("Enter y coordinate.");
  //  string pieceYCoord = Console.ReadLine();
  //  int pieceY = int.Parse(pieceYCoord);
  //  bool attackable = q.CheckAll(pieceX, pieceY);
  //  if(attackable) {
  //    Console.WriteLine("The queen can attack the other piece.");
  //    Console.WriteLine("Piece out.");
  //  } else {
  //    Console.WriteLine("The queen can't attack the other piece.");
  //    Console.WriteLine("Piece out.");
  //  }
  //  Main();
  }
}