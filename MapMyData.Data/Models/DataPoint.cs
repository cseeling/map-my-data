namespace MapMyData.Data.Models
{
    public class DataPoint : BaseModel
    {
        public int StateId { get; set; }
        public State State { get; set; }
        public string Value { get; set; }
        public string Color { get; set; }
    }
}
