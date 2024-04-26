using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ApiCreditSimulator.Shared.Bases;

namespace ApiCreditSimulator.Shared.Entities
{
    public class UserLog : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}