﻿namespace ServiceLayer.IDashboardServices
{
    public interface IDashboardService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        IEnumerable<T> GetAllDashboard();
        //IEnumerable<T> GetById(int Id);
    }
}
