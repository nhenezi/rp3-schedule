using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rp3_Schedule
{
	[Table("schedule")]
    class Schedule
    {
		[Key, Column("id")]
        public int Id { get; set; }
		[Column("name")]
        public String Name { get; set; }

        private readonly ObservableListSource<Allocation> _Allocations =
               new ObservableListSource<Allocation>();
        public virtual ObservableListSource<Allocation> Allocations { get { return _Allocations; } }
    }
}
