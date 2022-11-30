using System;
using System.Drawing;
using System.Collections.Generic;

Universe universe = new Universe();
universe.Add(new Earth());
universe.Add(new Mon());
universe.Add(new Satellite());

App.Run(universe, 1000);

public abstract partial class Body
{
    public PointF Position { get; set; }
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }
    public Color Color { get; set; }
    public float Size { get; set; }
    public float Mass { get; set; }
}

public class Earth : Body
{
    public Earth()
    {
        Position = PointF.Empty;
        VelocityX = 0f;
        VelocityY = 0f;
        Color = Color.Blue;
        Mass = 5.9742E24f;
        Size = 127.562f; // 12756,2 km
    }
}

public class Mon : Body
{
    public Mon()
    {
        Position = new PointF(0f, -385);
        VelocityX = 0.001f; // 1 km/s
        VelocityY = 0;
        Color = Color.White;
        Mass = 7.36E22f;
        Size = 3.4748f; // 3474,8 km
    }
}

public class Satellite : Body
{
    public Satellite()
    {
        const float G = 6.6743E-11f;
        Position = new PointF(0f, -127.562f / 2 - 10);
        VelocityY = 0;
        Color = Color.Gray;
        Mass = 500000f;
        Size = 3f; // 12756,2 km
        VelocityX = (float)Math.Sqrt(G * 5.9742E24f 
            / (1000 * 1000 * -Position.Y))
            / (1000 * 1000);
    }
}

public class Universe
{
    public List<Body> Bodies { get; private set; }
        = new List<Body>();
    
    public void Add(Body body)
        => Bodies.Add(body);

    public void Update(float dt)
    {
        foreach (var x in Bodies)
        {
            foreach (var y in Bodies)
            {
                if (x == y)
                    continue;
                
                x.ApplyForce(y, dt);
            }
        }

        foreach (var x in Bodies)
            x.Update(dt);
    }
}