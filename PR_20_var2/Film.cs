namespace PR_20_var2
{
    public class Film
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}