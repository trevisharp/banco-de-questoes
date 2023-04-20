public class CellRobot
{
    public CellRobot(Maze maze, int x, int y)
    {
        this.maze = maze;
        this.X = x;
        this.Y = y;
    }

    private Maze maze;

    public int X { get; private set; }
    public int Y { get; private set; }

    public bool WallUp => maze.MazeData[X + 10 * (Y - 1)] == Piece.Wall || maze.MazeData[X + 10 * (Y - 1)] == Piece.Cell;
    public bool WallDown => maze.MazeData[X + 10 * (Y + 1)] == Piece.Wall || maze.MazeData[X + 10 * (Y + 1)] == Piece.Cell;
    public bool WallLeft => maze.MazeData[(X - 1) + 10 * Y] == Piece.Wall || maze.MazeData[(X - 1) + 10 * Y] == Piece.Cell;
    public bool WallRigth => maze.MazeData[(X + 1) + 10 * Y] == Piece.Wall || maze.MazeData[(X + 1) + 10 * Y] == Piece.Cell;

    public void MoveUp()
    {
        if (WallUp)
            return;
        
        maze.MazeData[X + 10 * Y] = Piece.Empty;
        Y--;
        maze.MazeData[X + 10 * Y] = Piece.NewCell;
    }

    public void MoveDown()
    {
        if (WallDown)
            return;
        
        maze.MazeData[X + 10 * Y] = Piece.Empty;
        Y++;
        maze.MazeData[X + 10 * Y] = Piece.NewCell;
    }

    public void MoveLeft()
    {
        if (WallLeft)
            return;
        
        maze.MazeData[X + 10 * Y] = Piece.Empty;
        X--;
        maze.MazeData[X + 10 * Y] = Piece.NewCell;
    }

    public void MoveRigth()
    {
        if (WallRigth)
            return;
        
        maze.MazeData[X + 10 * Y] = Piece.Empty;
        X++;
        maze.MazeData[X + 10 * Y] = Piece.NewCell;
    }

    public void CloneUp()
    {
        if (WallUp)
            return;
        
        maze.MazeData[X + 10 * (Y - 1)] = Piece.NewCell;
    }

    public void CloneDown()
    {
        if (WallDown)
            return;
        
        maze.MazeData[X + 10 * (Y + 1)] = Piece.NewCell;
    }

    public void CloneLeft()
    {
        if (WallLeft)
            return;
        
        maze.MazeData[(X - 1) + 10 * Y] = Piece.NewCell;
    }

    public void CloneRigth()
    {
        if (WallRigth)
            return;
        
        maze.MazeData[(X + 1) + 10 * Y] = Piece.NewCell;
    }
}