using System;

namespace Chess {
  public class King : Piece {

    public King(Space space, string color) : base (space, color){}

    public override bool CheckAll(int x, int y) {
      return true;
    }
  }
}