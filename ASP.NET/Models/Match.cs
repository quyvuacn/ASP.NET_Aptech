namespace ASP.NET_VSCode.Models
{
    public class Match
    {
        public Match(int Id, Team Team_1, Team Team_2, int[] Score)
        {
            this.Id = Id;
            this.Team_1= Team_1;
            this.Team_2= Team_2;
            this.Score = Score;
        } 
        public int Id { get; set; }

        public Team Team_1 { get; set; }

        public Team Team_2 { get; set; }
        public int[] Score { get; set; }

    }
}
