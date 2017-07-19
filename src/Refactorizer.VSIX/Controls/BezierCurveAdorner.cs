﻿using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Refactorizer.VSIX.Controls
{
    class BezierCurveAdorner : Adorner

    {
        public BezierCurveAdorner(UIElement adornedElement, Point from, Point controlOne, Point controlTwo, Point to) : base(adornedElement)
        {
            From = from;
            ControlOne = controlOne;
            ControlTwo = controlTwo;
            To = to;
        }

        public bool IsSelected { get; set; }


        public Point From { get; set; }

        public Point ControlOne { get; set; }

        public Point ControlTwo { get; set; }

        public Point To { get; set; }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var color = IsSelected ? Colors.OrangeRed : Colors.White;
            var brush = new SolidColorBrush(color) {Opacity = IsSelected ? 1 : 0.5};
            var pen = new Pen(brush, 1.5);

            var pathFigure = new PathFigure();
            pathFigure.StartPoint = From;
            pathFigure.Segments.Add(new BezierSegment(ControlOne, ControlTwo, To, true));

            var pathGeometry = new PathGeometry(new[] {pathFigure});

            drawingContext.DrawGeometry(Brushes.Transparent, pen, pathGeometry);
        }
    }
}