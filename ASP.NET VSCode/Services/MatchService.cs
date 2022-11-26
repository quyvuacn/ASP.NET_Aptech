
using ASP.NET_VSCode.Models;

namespace WorldCup2022.Services
{
    public class  MatchService : List<Match>
    {
        public MatchService() {
            Add(new Match(1, 
                new Team("Quatar", ""), 
                new Team("Ecuador", ""), 
                new int[] { 0, 2 })
            );

            Add(new Match(2, 
                new Team("Anh", ""),
                new Team("Iran", ""),
                new int[] { 6, 2 })
            );

            Add(new Match(3, 
                new Team("Hoa Kì", ""),
                new Team("Wales", ""),
                new int[] { 1, 1 })
            ); 
            
            Add(new Match(4, 
                new Team("Đan mạch", ""),
                new Team("Tunisia", ""),
                new int[] { 0, 0 })
            ); 
            
            Add(new Match(5, 
                new Team("Pháp", ""),
                new Team("Úc", ""),
                new int[] { 4, 1 })
            ); 
            
            Add(new Match(6, 
                new Team("Đức", ""),
                new Team("Nhật Bản", ""),
                new int[] { 1, 2 })
            ); 
            
            Add(new Match(7, 
                new Team("Bỉ", ""),
                new Team("Canada", ""),
                new int[] { 1, 0 })
            );
        }


    }
}
