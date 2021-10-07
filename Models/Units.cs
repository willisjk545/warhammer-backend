using System;
using System.Collections.Generic;

namespace _40K.Models
{
    public partial class Units
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArmyID { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public int UserID { get; set; }
    }
}
