using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IDiscountService:IGenericService<Discount>
	{
		void TDiscountChangeStatusToTrue(int id);
		void TDiscountChangeStatusToFalse(int id);
		List<Discount> TGetListByStatusTrue();
	}
}
