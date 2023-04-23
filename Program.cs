using System;
using System.Collections.Generic;

namespace ShapeClass
{
    public class Shape
    {
        public string Color { get; set; }
        public bool Filled { get; set; }
        public Shape()
        {
            Color = "Green";
            Filled = true;
        }
        public virtual double GetArea()
        {
            return 0;
        }
        public virtual void Resize(double percent) { }


    }
    public interface IResizable
    {
        void Resize(double percent);
    }
    public class Circle : Shape, IResizable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override string ToString()
        {
            return "Circle: radius = " + Radius;
        }
        public override void Resize(double percent)
        {
            Radius *= (1 + percent / 100);
        }
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    public class Rectangle : Shape, IResizable
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override string ToString()
        {
            return "Rectangle: width = " + Width + ", height = " + Height;
        }
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override void Resize(double percent)
        {
            Width *= percent / 100.0;
            Height *= percent / 100.0;
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle, IResizable
    {
        public double Side
        {
            get { return Width; }
            set { Width = Height = value; }
        }
        public override string ToString()
        {
            return "Square: side = " + Side;
        }
        public Square(double side) : base(side, side)
        {
        }

        void IResizable.Resize(double percent)
        {
            double factor = 1 + percent / 100.0;
            Width *= factor;
            Height *= factor;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
       
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle(2));
            shapes.Add(new Rectangle(3, 4));
            shapes.Add(new Square(5));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Before resize:");
                Console.WriteLine(shape.ToString());
                double areaBeforeResize = shape.GetArea();
                Console.WriteLine("Area before resize: " + areaBeforeResize);
               
                double resizeFactor = rand.Next(1, 101);
                shape.Resize(resizeFactor);
                
                Console.WriteLine("After resize:");
                Console.WriteLine(shape.ToString());
                double areaAfterResize = shape.GetArea();
                Console.WriteLine("Area after resize: " + areaAfterResize);
            }

        }
    }
}
