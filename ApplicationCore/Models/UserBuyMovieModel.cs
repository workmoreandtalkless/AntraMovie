using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    class UserBuyMovieModel
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int MovieId { get; set; }
    }
}
