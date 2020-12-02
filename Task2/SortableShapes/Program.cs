using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SortableShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            var side = 1.1234D;
            var radius = 1.1234D;
            var triangleBase = 5D;
            var height = 2D;

            var shapes = new List<Shape>{                          
                            new Triangle(triangleBase, height),
                            new Circle(radius),
                            new Square(side),
                            new Rectancgle(side,height)
            };
            shapes.Sort();

            foreach(var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }
    }

    public class Shape : IComparable<Shape>
    {
        private double _area;
        public void calculateArea(double area)
        {
            _area = area;
        }

        public int CompareTo([AllowNull] Shape other)
        {
            return _area.CompareTo(other._area);
        }
    }

    public class Rectancgle : Shape
    {
        
        public Rectancgle(double width, double height)
        {
            calculateArea(width * height);
        }
    }
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            calculateArea(radius * radius * Math.PI);
        }
    }
    public class Triangle : Shape
    {
        public Triangle(double triangleBase, double height)
        {
            calculateArea(triangleBase * height/2);
        }
    }
    public class Square : Shape
    {
        public Square(double side)
        {
            calculateArea(side * side);
        }
    }
}
