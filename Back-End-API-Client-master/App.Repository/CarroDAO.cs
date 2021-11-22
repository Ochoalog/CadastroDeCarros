using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    public class CarroDAO
    {
        private readonly string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private readonly IDbConnection connection;

        public CarroDAO()
        {
            
            connection = new SqlConnection(ConnectionString);

            connection.Open();
        }

        public List<CarroDTO> ListCarrosDB(int? id)
        {
            try
            {
                var listCarros = new List<CarroDTO>();

                IDbCommand selectCmd = connection.CreateCommand();

                if (id == null)
                {
                    selectCmd.CommandText = "select * from DBCARROS";

                }
                else
                {
                    selectCmd.CommandText = $"select * from DBCARROS where id = {id}";
                }

                IDataReader result = selectCmd.ExecuteReader();
                while (result.Read())
                {
                    CarroDTO Carro = new CarroDTO
                    {
                        Id = Convert.ToInt32(result["ID"].ToString()),
                        Marca = result["MARCA"].ToString(),
                        Modelo = result["MODELO"].ToString(),
                        Placa = result["PLACA"].ToString(),
                        Roda = Convert.ToInt32(result["RODA"]),
                        Porta = Convert.ToInt32(result["PORTA"]),
                        Cor = result["COR"].ToString(),
                        Combustivel = result["COMBUSTIVEL"].ToString(),
                        Preco = Convert.ToDecimal(result["PRECO"])
                    };

                    listCarros.Add(Carro);
                }
                return listCarros;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }           
        }

        public void InsertCarroDB(CarroDTO Carro)
        {
            try
            {
                IDbCommand insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "INSERT INTO DBCARROS (MARCA, MODELO, PLACA, RODA, PORTA, COR, COMBUSTIVEL, PRECO) VALUES (@marca, @modelo, @placa, @roda, @porta, @cor, @combustivel, @preco)";

                IDbDataParameter parameterMarca = new SqlParameter("marca", Carro.Marca);
                insertCmd.Parameters.Add(parameterMarca);

                IDbDataParameter parameterModelo = new SqlParameter("modelo", Carro.Modelo);
                insertCmd.Parameters.Add(parameterModelo);

                IDbDataParameter parameterPlaca = new SqlParameter("placa", Carro.Placa);
                insertCmd.Parameters.Add(parameterPlaca);

                IDbDataParameter parameterRoda = new SqlParameter("roda", Carro.Roda);
                insertCmd.Parameters.Add(parameterRoda);

                IDbDataParameter parameterPorta = new SqlParameter("porta", Carro.Porta);
                insertCmd.Parameters.Add(parameterPorta);

                IDbDataParameter parameterCor = new SqlParameter("cor", Carro.Cor);
                insertCmd.Parameters.Add(parameterCor);

                IDbDataParameter parameterCombustivel= new SqlParameter("combustivel", Carro.Combustivel);
                insertCmd.Parameters.Add(parameterCombustivel);

                IDbDataParameter parameterPreco = new SqlParameter("preco", Carro.Preco);
                insertCmd.Parameters.Add(parameterPreco);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateCarroDB(CarroDTO Carro)
        {
            try
            {
                IDbCommand updateCmd = connection.CreateCommand();
                updateCmd.CommandText = "UPDATE DBCARROS SET MARCA = @marca, MODELO = @modelo, PLACA = @placa, RODA = @roda, PORTA = @porta, COR = @cor, COMBUSTIVEL = @combustivel WHERE ID = @id";

                IDbDataParameter parameterMarca = new SqlParameter("marca", Carro.Marca);
                updateCmd.Parameters.Add(parameterMarca);

                IDbDataParameter parameterModelo = new SqlParameter("modelo", Carro.Modelo);
                updateCmd.Parameters.Add(parameterModelo);

                IDbDataParameter parameterPlaca = new SqlParameter("placa", Carro.Placa);
                updateCmd.Parameters.Add(parameterPlaca);

                IDbDataParameter parameterRoda = new SqlParameter("roda", Carro.Roda);
                updateCmd.Parameters.Add(parameterRoda);

                IDbDataParameter parameterPorta = new SqlParameter("porta", Carro.Porta);
                updateCmd.Parameters.Add(parameterPorta);

                IDbDataParameter parameterCor = new SqlParameter("cor", Carro.Cor);
                updateCmd.Parameters.Add(parameterCor);

                IDbDataParameter parameterCombustivel = new SqlParameter("combustivel", Carro.Combustivel);
                updateCmd.Parameters.Add(parameterCombustivel);

                IDbDataParameter parameterPreco = new SqlParameter("preco", Carro.Preco);
                updateCmd.Parameters.Add(parameterPreco);

                IDbDataParameter parameterId = new SqlParameter("id", Carro.Id);
                updateCmd.Parameters.Add(parameterId);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteCarroDB(int id)
        {
            try
            {
                IDbCommand deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM DBCARROS WHERE ID = @id";

                IDbDataParameter parameterId = new SqlParameter("id", id);
                deleteCmd.Parameters.Add(parameterId);
                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}