namespace Chess {
public abstract class Piece {

  public string Color { get; set;}
  
  public virtual string Name { get; set;}

  public Space Space { get; set;}

  public int xCoord { get; set; }

  public int yCoord { get; set; }

  public Piece(Space space, string color) {
    Color = color;
    Name = Color.Substring(0,1) + this.GetType().Name.Substring(0,1);
    Space = space;
    xCoord = Space.xCoord;
    yCoord = Space.yCoord;
  }

  public abstract bool CheckAll(int x, int y);
  }
}
