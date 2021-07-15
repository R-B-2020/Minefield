namespace Minefield.Business.Domain
{
    public class Cell
    {
        public Cell()
        {
            this.Value = string.Empty;
            this.IsBomb = false;
        }
        public bool IsBomb { get; set; }

        public string Value { get; set; }

        public Cell Clone()
        {
            return this.MemberwiseClone() as Cell;
        }
    }
}