using System.Runtime.Serialization;

namespace CLC.Models
{
    [DataContract]
    public class CellGrid
    {
        [DataMember] public int Id { get; set; } = -1;
        [DataMember] public Cell[,] Cells { get; set; }
        [DataMember] public int Height { get; set; }
        [DataMember] public int Width { get; set; }
        [DataMember] public bool Win { get; set; } = false;
        [DataMember] public bool Lose { get; set; } = false;
        [DataMember] public int Time { get; set; } = 0;
        [DataMember] public int Moves { get; set; } = 0;


        public CellGrid(int h, int w)
        {
            Cells = new Cell[h, w];
            Height = h;
            Width = w;
        }
    }
}