using System;

namespace Chess {
public class Queen : Piece {
  
  public Queen(Space space, string color) : base (space, color) {
  }

  public override bool CheckAll(int x, int y) {
    if(CheckSameColumn(x, y) || CheckSameRow(x, y) || CheckDiagonal(x,y)) {
      return true;
    } else {
      return false;
    }
  }
  public bool CheckSameColumn(int x, int y) {
    if(xCoord == x) {
      return true;
    } else {
      return false;
    }
  }
  public bool CheckSameRow(int x, int y) {
    if(yCoord == y) {
      return true;
    } else {
      return false;
    }
  }
  public bool CheckDiagonal(int x, int y) {
    int rise = (y - yCoord);
    int run = (x - xCoord);
    if(Math.Abs(rise/run) == 1) {
      return true;
    } else {
      return false;
    }
  }
}
}