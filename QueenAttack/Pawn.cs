namespace Chess {

  public class Pawn : Piece {

  public Pawn() {}
   public Pawn(Space space, string color) : base (space, color){}

  public override bool CheckAll(int x, int y) {
      if(CheckSameColumn(x, y) || CheckSameRow(x, y)) {
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
  }
}