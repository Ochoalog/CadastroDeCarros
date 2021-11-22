using App.Domain;
using App.Repository;
using System;
using System.Collections.Generic;

namespace WebAppCarros.Models
{
    public class CarroModel
    {
        public List<CarroDTO> ListCarros(int? id = null)
        {
            try
            {
                var CarroDB = new CarroDAO();
                return CarroDB.ListCarrosDB(id);
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao listar Carroes: Erro = ${ex.Message}");
            }
        }

        public void Insert(CarroDTO Carro)
        {
            try
            {
                var CarroDB = new CarroDAO();
                CarroDB.InsertCarroDB(Carro);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir Carroe: Erro = ${ex.Message}");
            }
        }

        public void Update(CarroDTO Carro)
        {
            try
            {
                var CarroDB = new CarroDAO();
                CarroDB.UpdateCarroDB(Carro);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar Carroe: Erro = ${ex.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var CarroDB = new CarroDAO();
                CarroDB.DeleteCarroDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar Carroe: Erro = ${ex.Message}");
            }
        }
    }
}