using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Enums
{
	public enum StatusEnum
	{
		AwaitingOfferReveives = 1,
		PendingClientConfirmation = 2,     
		PendingProviderConfirmation = 3,   
		Completed = 4,   
		Cancelled = 5    
	}
}
