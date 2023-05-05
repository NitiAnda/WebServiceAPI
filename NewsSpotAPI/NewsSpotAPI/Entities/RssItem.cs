namespace NewsSpotAPI.Entities
{
    [Table("News")]
    public class RssItem
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public DateTime? PublishDate { get; set; }
        [ForeignKey("Id")]
        public int? ChannelId { get; set; }
        public RssChannel? Channel { get; set; }
    }
}
