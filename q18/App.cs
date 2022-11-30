using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public static class App
{
    public static void Run(Universe universe, int N)
    {
        ApplicationConfiguration.Initialize();

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;

        PictureBox pb = new PictureBox();
        pb.Dock = DockStyle.Fill;
        form.Controls.Add(pb);

        Bitmap bmp = null;
        Graphics g = null;
        Point center = Point.Empty;

        Timer tm = new Timer();
        tm.Interval = 40;

        form.KeyDown += (o, e) =>
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        };

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Image = bmp;
            tm.Start();
            center = new Point(pb.Width / 2, pb.Height / 2);
        };

        tm.Tick += delegate
        {
            g.Clear(Color.Black);

            for (int i = 0; i < N; i++)
                universe.Update(60 * 0.025f);

            foreach (var x in universe.Bodies)
                x.Draw(g, center);

            pb.Refresh();
        };

        Application.Run(form);
    }
}

public abstract partial class Body
{
    public void Draw(Graphics g, Point center)
    {
        g.FillEllipse(new SolidBrush(this.Color),
            Position.X - Size / 2 + center.X,
            Position.Y - Size / 2 + center.Y,
            Size, Size);
    }

    public void Update(float dt)
    {
        Position = new PointF(
            Position.X + VelocityX * dt,
            Position.Y + VelocityY * dt
        );
    }

    public void ApplyForce(Body other, float dt)
    {
        const float G = 6.6743E-11f;
        float r = 1000 * 1000 * Distance(other);
        float force = G * this.Mass * other.Mass / (r * r);
        float acceleration = force / Mass;
        float dx = 1000 * 1000 * (other.Position.X - this.Position.X);
        float dy = 1000 * 1000 * (other.Position.Y - this.Position.Y);
        this.VelocityX += (dt * acceleration * dx / r) / 1000 / 1000;
        this.VelocityY += (dt * acceleration * dy / r) / 1000 / 1000;
    }

    public float Distance(Body other)
    {
        float dx = other.Position.X - this.Position.X;
        float dy = other.Position.Y - this.Position.Y;
        return (float)Math.Sqrt(dx * dx + dy * dy);
    }
}