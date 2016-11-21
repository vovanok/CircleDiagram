using System.ComponentModel;
using System.Drawing;

namespace CircleDiagram.Editor.PropertiesAggregators
{
    public class CircleDiagramMainProperies
    {
        [DisplayName(@"Количество уровней")]
        [Category(@"Основные")]
        public int CountLevels { get; set; }

        [DisplayName(@"Цвет фона")]
        [Category(@"Заливка")]
        public Color MainBackgroundColor { get; set; }

        [DisplayName(@"Цвет кольца")]
        [Category(@"Заливка")]
        public Color RingBackgroundColor { get; set; }

        [DisplayName(@"Цвет интервала")]
        [Category(@"Заливка")]
        public Color IntervalBackgroundColor { get; set; }

        [DisplayName(@"Цвет границы вершины")]
        [Category(@"Границы")]
        public Color NodeBorderColor { get; set; }

        [DisplayName(@"Толщина границы вершины")]
        [Category(@"Границы")]
        public float NodeBorderThickness { get; set; }

        [DisplayName(@"Цвет границы разметки")]
        [Category(@"Границы")]
        public Color RingBorderColor { get; set; }

        [DisplayName(@"Толщина границы разметки")]
        [Category(@"Границы")]
        public float RingBorderThickness { get; set; }

        [DisplayName(@"Цвет связи вершин")]
        [Category(@"Связи вершин")]
        public Color RelationshipPenColor { get; set; }

        [DisplayName(@"Толщина связи вершин")]
        [Category(@"Связи вершин")]
        public float RelationshipPenThickness { get; set; }

        [DisplayName(@"Цвет текста нумерации")]
        [Category(@"Нумерация уровней")]
        public Color NumerationColor { get; set; }

        [DisplayName(@"Шрифт текста нумерации")]
        [Category(@"Нумерация уровней")]
        public Font NumerationFont { get; set; }

        [DisplayName(@"Начинать с")]
        [Category(@"Нумерация уровней")]
        public int NumerationBeginNumber { get; set; }

        [DisplayName(@"Перевернуть номерацию")]
        [Category(@"Нумерация уровней")]
        public bool NumerationIsInverted { get; set; }
    }
}
