using System;

namespace Chess {

  public class Knight : Piece {

    public override string Name { get; set;}
    public Knight(Space space, string color) : base (space, color) {
      Name = Color.Substring(0,1) + "Kn"; 
    }
    public override bool CheckAll(int x, int y){
      int run = x -  xCoord;
      int rise = y - yCoord;
      if((Math.Abs(run) == 2 && Math.Abs(rise) == 1 ) ||  (Math.Abs(run) == 1 && Math.Abs(rise) == 2)) {
        return true;
      }
      else {
        return false;
      }
    }
  }
}