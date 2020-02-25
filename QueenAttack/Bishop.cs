using System;

namespace Chess {
  public class Bishop : Piece 
  {
    public Bishop(Space space, string color) : base (space, color){
    }
    public override bool CheckAll(int x, int y) 
    {
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