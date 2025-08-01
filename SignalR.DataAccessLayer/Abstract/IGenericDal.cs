﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class, new()
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T GetById(int id);
		List<T> GetListAll();
	}
}
