namespace SportsClubModel.Domain
{
    public class ChallengeRegistration
    {
        public long Id { get; set; }
        public long ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }
        public long MemberId { get; set; }
        public virtual Member Member { get; set; }
        public string Team {get;set;}

    }
}