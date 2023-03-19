using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicToeAPI.Models
{
    
        public class Game
        {
            public int Id { get; set; }
            public string? Board { get; set; }
            public int CurrentPlayer { get; set; }
            public bool IsOver { get; set; }
            public int Winner { get; set; }
        }


}

