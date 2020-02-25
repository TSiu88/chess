namespace Chess {

  public class Pawn : Piece {

   public Pawn(Space space, string color) : base (space, color){}
   
   public override bool CheckAll(int x, int y){
     return true;
   }
  }
}