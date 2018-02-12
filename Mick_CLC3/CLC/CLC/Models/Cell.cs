
namespace CLC.Models
{
    public class Cell
    {
        public bool Mine { set; get; }
        public bool Flagged { get; set; } = false;
        public bool Checked { set; get; } = false;
        public int Adjacent { get; set; } = 0;
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}