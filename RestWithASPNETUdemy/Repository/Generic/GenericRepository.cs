using Microsoft.EntityFrameworkCore;
using RestWithASPNETUdemy.Data;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BancoContext _bancoContext;
        private DbSet<T> dataSet;

        /*Nota: O _bancoConext chama o banco e o dataset vai referenciar a tabela que vai ser 
        acessada no banco.
        Precisamos dos dois para acessar o banco com o tipo expessífico e o outro para salvar*/
        public GenericRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            dataSet = bancoContext.Set<T>();
        }
        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _bancoContext.SaveChanges();
                return item;
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }

        }

        public void Delete(long Id)
        {
            try
            {
                var result = FindById(Id);
                if (result != null)
                {
                    dataSet.Remove(result);
                    _bancoContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Não encontrado");
                }
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public bool Exists(long id)
        {
            try
            {
                return dataSet.Any(x => x.Id == id);

            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long Id)
        {
            return dataSet.FirstOrDefault(x => x.Id == Id);
        }

        public T Update(T findId, T item)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _bancoContext.Entry(result).CurrentValues.SetValues(item);
                    _bancoContext.SaveChanges();
                    return item;
                }
                catch (Exception erro)
                {

                    throw new Exception(erro.Message);
                }
            }
            else
            {
                return null;
            }

        }
    }
}
