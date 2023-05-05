namespace NewsSpotAPI.Entities
{
    [Table("Publisher")]
    public class RssChannel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Link { get; set; }
        public ICollection<RssItem>? Items { get; set; }
    }

}
