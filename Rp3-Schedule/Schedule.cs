using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rp3_Schedule
{
    class Schedule
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
    }
}
