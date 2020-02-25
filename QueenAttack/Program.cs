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

  public void Turn() {
    Console.WriteLine(board.Color + "'s turn");
    Console.WriteLine("To select a piece rovide x and y coordinates for");
  }
  static void SelectPiece()
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
    //PrintBoard();
    Console.ReadLine();

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