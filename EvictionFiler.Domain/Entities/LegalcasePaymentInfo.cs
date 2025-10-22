﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domain.Entities
{
    public class LegalcasePaymentInfo
    {
        [Key]
        public Guid Id { get; set; }
        public int AccountBalance { get; set; }
        public int AccountCredit { get; set; }
        public int BalanceonCase { get; set; }
        public int LastPayment { get; set; }

    }
}
