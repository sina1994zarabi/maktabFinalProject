using App.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Entities
{
	public class Status
	{
        public StatusEnum Id { get; set; }
        public string Name { get; set; }
    }
}
