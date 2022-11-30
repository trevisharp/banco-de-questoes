using System;
using System.Drawing;
using System.Collections.Generic;

Universe universe = new Universe();
universe.Add(new Earth());
universe.Add(new Mon());
universe.Add(new Rocket());

App.Run(universe, 100);

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

public class Rocket : Body
{
    public Rocket()
    {
        Position = new PointF(0f, -127.562f / 2); // 12756,2 km;
        VelocityX = 0f;
        VelocityY = -0.012f;
        Color = Color.Red;
        Mass = 500000f; // 500 tonelasdas
        Size = 5f; // fantasioso, apenas para vizualização
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