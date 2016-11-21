using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace CircleDiagram.Editor.PropertiesAggregators
{
    public class CircleDiagramNodeProperies
    {
        [DisplayName(@"Название")]
        [ReadOnly(true)]
        [Category(@"Основные")]
        public string Name { get; set; }

        [DisplayName(@"Цвет фона")]
        [Category(@"Основные")]
        public Color BackgroundColor { get; set; }

        [DisplayName(@"Угол начала сектора")]
        [Category(@"Положение")]
        public float StartAngle { get; set; }

        [DisplayName(@"Длина сектора")]
        [Category(@"Положение")]
        public float SweepAngle { get; set; }

        [DisplayName(@"Уровень")]
        [Category(@"Положение")]
        public int StartCircleNumber { get; set; }

        [DisplayName(@"Количество занимаемых уровней")]
        [Category(@"Положение")]
        public int CountCircles { get; set; }

        [DisplayName(@"Текст")]
        [Category(@"Текст")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Text { get; set; }

        [DisplayName(@"Цвет текста")]
        [Category(@"Текст")]
        public Color TextColor { get; set; }

        [DisplayName(@"Шрифт текста")]
        [Category(@"Текст")]
        public Font TextFont { get; set; }
    }
}
