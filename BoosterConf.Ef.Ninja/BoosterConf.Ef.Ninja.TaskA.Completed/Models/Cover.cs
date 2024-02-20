namespace BoosterConf.Ef.Ninja.TaskA.Solved.Models
{
    public record Cover
    {
        public Guid Id { get; set; }
        public required CoverType Type { get; set; }
        public required DateTimeOffset StartDate { get; set; }
        public required DateTimeOffset EndDate { get; set; }
        public required decimal Premium { get; set; }
        public required Customer Customer { get; set; }
        public ICollection<Claim>? Claims { get; set; }
    }
}
