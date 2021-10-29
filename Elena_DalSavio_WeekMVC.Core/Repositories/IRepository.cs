﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elena_DalSavio_WeekMVC.Core
{
    public interface IRepository<T>
    {
        public List<T> Fetch();
        public T Add(T item);
        public T Update(T item);
        public bool Delete(T item);
    }
}
