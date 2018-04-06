using System.Runtime.Serialization;

namespace CLC.Models 
{
    [DataContract] 
    public class CellGrid
    {
        [DataMember] public Cell[,] Cells { get; set; }
        [DataMember] public int Height { get; set; }
        [DataMember] public int Width { get; set; }
        [DataMember] public bool Win { get; set; } = false;
        [DataMember] public bool Lose { get; set; } = false;

        public CellGrid(int h, int w)
        {
            Cells = new Cell[h, w];
            Height = h;
            Width = w;
        }
    }
}