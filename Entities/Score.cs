using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ScoreAPI.Entities
{
    public class Score
    {
        public Guid Id {get; set;}
        public required string Name {get; set; }
        public int Points {get; set; }
    }
}