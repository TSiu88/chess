using System;
using System.Collections.Generic;

namespace Chess {
  public class Board {
    public string Color { get; set; }
    public Piece currentPiece {get; set; }
    public List<List<Space>> spaces = new List<List<Space>>();
    
    public Board() {
      Color = "White";
      for(int i = 0; i < 8; i++) {
        List<Space> row = new List<Space>();
        for(int j = 0; j < 8; j++) {
          row.Add(new Space(i, j));
        }
        spaces.Add(row);
      }
     InitialChessSetup();
    }
    public void InitialChessSetup() {
      for(int row = 0; row < 8; row++) {
        for(int col = 0; col < 8; col++) {
          string color;
          if(row <= 1) {
            color = "Black";
            if(row == 0) {
              switch(col) {
                case 0:
                new Rook(spaces[col][row], color);
                break;
                case 1:
                new Knight(spaces[col][row], color);
                break;
                case 2:
                new Bishop(spaces[col][row], color);
                break;
                case 3:
                new Queen(spaces[col][row], color);
                break;
                case 4:
                new King(spaces[col][row], color);
                break;
                case 5:
                new Bishop(spaces[col][row], color);
                break;
                case 6:
                new Knight(spaces[col][row], color);
                break;
                case 7:
                new Rook(spaces[col][row], color);
                break;
                default:
                Console.WriteLine("Error");
                break;
              }
              // new Pawn(spaces[col][6], color);
            } else if(row == 1) {
              new Pawn(spaces[col][row], color);
            }
          } else if(row >= 6) {
            color = "White";
            if(row == 6) {
              new Pawn(spaces[col][row], color);
            } else if(row == 7) {
               switch(col) {
                case 0:
                new Rook(spaces[col][row], color);
                break;
                case 1:
                new Knight(spaces[col][row], color);
                break;
                case 2:
                new Bishop(spaces[col][row], color);
                break;
                case 3:
                new Queen(spaces[col][row], color);
                break;
                case 4:
                new King(spaces[col][row], color);
                break;
                case 5:
                new Bishop(spaces[col][row], color);
                break;
                case 6:
                new Knight(spaces[col][row], color);
                break;
                case 7:
                new Rook(spaces[col][row], color);
                break;
                default:
                Console.WriteLine("Error");
                break;
              }
            }
          }
        }
      }
    }
          // Pawn whitePawn = new Pawn(spaces[col][6], "White");
          // Pawn blackPawn = new Pawn(spaces[col][1], "Black");
          //if the row is less than or equal to 1 apply black color
          //if the row is equal to 0, add the higher piece set
          //if the row is equal to 1 then do black pawns
          //if the row is greater than or equal to 6 apply white color
          //
          //if the row is equal to 6 do the white pawns
          //if the row is 7 add higher
          //
          
      // for(int j = 0; j < 8 j++) {
      //   string color;
      //   int row =0;
      //   if(j <= 1) {
          
      //   }
      // }
      // for(int j = 0; j < 2; j++) {
      //   string color;
      //   int row = 0;
      //   if(j == 0) {
      //     color = "Black";
      //     row = 0;
      //   } else {
      //     color = "White";
      //     row = 7;
      //   }
       

    public bool SelectPiece(int x, int y) {
      Console.WriteLine(Color);
      Space s = spaces[x][y];
      Piece p = s.Piece;
      Console.WriteLine(p.Name);
      if(Color == p.Color) {
        currentPiece = p;
        return true;
      } else {
        return false;
      }
    }
    public void ChangePlayer() {
      if(Color == "White") {
        Color = "Black";
      } else {
        Color = "White";
      }
    }

    public bool CheckSpacesBetweenColumn(int rise) {
      if(rise > 0) {
        while(rise > 1){
          if (this.spaces[currentPiece.xCoord][currentPiece.yCoord + (rise - 1)] != null){
            return false;
          }
          rise --;
        }
      } else {
        while(rise < -1){
          if (this.spaces[currentPiece.xCoord][currentPiece.yCoord + (rise + 1)] != null){
            return false;
          }
          rise ++;
        }
      }
      return true;
    }

    public bool CheckSpacesBetweenRow(int run) {
      if(run > 0) {
        while(run > 1){
          if (this.spaces[currentPiece.xCoord + (run - 1)][currentPiece.yCoord] != null){
            return false;
          }
          run --;
        }
      } else {
        while(run < -1){
          if (this.spaces[currentPiece.xCoord + (run + 1)][currentPiece.yCoord] != null){
            return false;
          }
          run ++;
        }
      }
      return true;
    }

    public bool CheckSpacesBetweenDiagonal(int rise, int run) {
      if((run > 0) && (rise > 0)) {
        while(rise > 1){
          if (this.spaces[currentPiece.xCoord + (rise - 1)][currentPiece.yCoord + (rise - 1)] != null){
            return false;
          }
          rise --;
        }
      } else if ((run < 0) && (rise < 0)) {
        while(rise < -1){
          if (this.spaces[currentPiece.xCoord + (rise + 1)][currentPiece.yCoord + (rise + 1)] != null){
            return false;
          }
          rise ++;
        }
      } else if ((run > 0) && (rise < 0)) {
        while ((run > 1) && (rise < -1)) {
          if (this.spaces[currentPiece.xCoord + (run - 1)][currentPiece.yCoord + (rise + 1)] != null){
            return false;
          }
          run--;
          rise ++;
        }
      } else {
        while ((run < -1) && (rise > 1)) {
          if (this.spaces[currentPiece.xCoord + (run + 1)][currentPiece.yCoord + (rise - 1)] != null){
            return false;
          }
          run++;
          rise --;
        }
      }
      return true;
    }
    public bool CheckViable(int x, int y) {
      List<Space> spaceList = spaces[x];
      Console.WriteLine(spaceList.Count);
      Space targetSpace = spaceList[y];
     

      // if you already have a piece in target, or your selected piece can't legally move like this, return false
      if (x == currentPiece.xCoord && y == currentPiece.yCoord)
      {
        return false;
      } else if(targetSpace.Piece != null) {
        if(targetSpace.Piece.Color == this.Color || !(currentPiece.CheckAll(x, y))) {
          return false;
       }
      }
      
      // (if the selected piece is a king or knight, skip the next step)
      // if there is no piece/an enemy piece in target, but there are pieces in the way, return false
      int run  = targetSpace.Piece.xCoord - currentPiece.xCoord; 
      int rise = targetSpace.Piece.yCoord - currentPiece.yCoord;
      if(targetSpace.xCoord == currentPiece.xCoord) {
        if(!CheckSpacesBetweenColumn(rise)) {
          return false;
        }
      }
      else if (targetSpace.yCoord == currentPiece.yCoord) {
        if(!CheckSpacesBetweenRow(run)) {
          return false;
        }
      }
      else {
        if(!CheckSpacesBetweenDiagonal(rise, run)) {
          return false;
        }
      }
      return true;
    }

    public void Move(int x, int y) {
      Space spaceBeforeMove = currentPiece.Space;
      this.spaces[x][y].Piece = currentPiece;
      spaceBeforeMove.Piece = null;
      // code for "en passant" If the chess piece moves past a pawn
    }
  }
  //   public bool Attack(int x, int y) {
  //     Space space = this.spaces[x][y];
  //     if(space.Piece != null) {
  //       space.Piece = null;
  //       space.Piece = this.currentPiece;
  //       return true;
  //     }
  //   }
  // }
}
