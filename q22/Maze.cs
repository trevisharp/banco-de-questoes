using System;
using System.Drawing;

using Pamella;

public enum Piece
{
    Empty,
    Wall,
    End,
    Cell,
    NewCell,
    Paint
}

public class Maze : View
{
    private Random rand = Random.Shared;

    public Controller controller = new Controller();

    public int StartX { get; set; }
    public int StartY { get; set; }

    public int EndX { get; set; }
    public int EndY { get; set; }
    public Piece[] MazeData { get; } = new Piece[100];

    public void Play()
    {
        if (MazeData[EndX + 10 * EndY] == Piece.Cell)
        {
            System.Windows.Forms.MessageBox.Show("Ganhou :)");
            return;
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var value = this.MazeData[i + 10 * j];

                if (value == Piece.Cell)
                {
                    CellRobot robot = new CellRobot(this, i, j);
                    controller.Control(robot);
                }
            }
        }

        for (int i = 0; i < 100; i++)
        {
            if (MazeData[i] == Piece.NewCell)
                MazeData[i] = Piece.Cell;
        }
    }

    protected override void OnStart(IGraphics g)
    {
        g.SubscribeKeyDownEvent(key =>
        {
            if (key == Input.Escape)
                App.Close();
            
            if (key == Input.Space)
                Play();
        });

        for (int i = 0; i < 10; i++)
        {
            MazeData[i] = Piece.Wall;
            MazeData[i + 90] = Piece.Wall;
            MazeData[10 * i] = Piece.Wall;
            MazeData[10 * i + 9] = Piece.Wall;
        }

        int br = rand.Next(1, 9);
        for (int i = 0; i < br; i++)
            MazeData[10 * i + 2] = Piece.Wall;
        for (int i = br + 1; i < 10; i++)
            MazeData[10 * i + 2] = Piece.Wall;
        
        int hor = 2 + ((br - 1 + rand.Next(6)) % 6);
        int br2 = rand.Next(3, 9);
        for (int i = 2; i < br2; i++)
            MazeData[i + hor * 10] = Piece.Wall;
        for (int i = br2 + 1; i < 10; i++)
            MazeData[i + hor * 10] = Piece.Wall;
        
        for (int i = hor; MazeData[br2 - 1 + 10 * (i + 1)] != Piece.Wall; i++)
            MazeData[br2 - 1 + 10 * i] = Piece.Wall; 
        for (int i = hor; MazeData[br2 + 1 + 10 * (i + 1)] != Piece.Wall; i++)
            MazeData[br2 + 1 + 10 * i] = Piece.Wall; 
        
        for (int i = hor; MazeData[br2 - 1 + 10 * (i - 1)] != Piece.Wall; i--)
            MazeData[br2 - 1 + 10 * i] = Piece.Wall; 
        for (int i = hor; MazeData[br2 + 1 + 10 * (i - 1)] != Piece.Wall; i--)
            MazeData[br2 + 1 + 10 * i] = Piece.Wall; 
        
        do
        {
            StartX = rand.Next(10);
            StartY = rand.Next(2);
        } while (MazeData[StartX + 10 * StartY] == Piece.Wall);

        do
        {
            EndX = rand.Next(10);
            EndY = rand.Next(8, 10);
        } while (MazeData[EndX + 10 * EndY] == Piece.Wall);

        MazeData[StartX + 10 * StartY] = Piece.Cell;
        MazeData[EndX + 10 * EndY] = Piece.End;
    }

    protected override void OnRender(IGraphics g)
    {
        g.Clear(Color.Black);

        int wid = g.Width;
        int hei = g.Height;
        int min = wid < hei ? wid : hei;
        RectangleF rect = new RectangleF(20 + (wid - min) / 2, 20 + (hei - min) / 2, min - 40, min - 40);
        float square = rect.Width / 10;

        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                var value = this.MazeData[i + 10 * j];

                g.FillRectangle(
                    rect.X + i * square,
                    rect.Y + j * square,
                    square, square,
                    value switch
                    {
                        Piece.Empty => Brushes.White,
                        Piece.Wall => Brushes.Brown,
                        Piece.Cell => Brushes.Green,
                        Piece.NewCell => Brushes.Green,
                        Piece.End => Brushes.Red,
                        _ => Brushes.Purple
                    }
                );
                
                g.DrawRectangle(
                    rect.X + i * square,
                    rect.Y + j * square,
                    square, square,
                    Pens.Black
                );
            }
        }


        Invalidate();
    }
}