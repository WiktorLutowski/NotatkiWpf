namespace NotatkiWpf
{
    public class Note
    {
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
