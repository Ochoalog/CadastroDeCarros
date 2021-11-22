using App.Domain;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAppCarros.Models;

namespace WebAppCarros.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/carro")]
    public class CarroController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous()]
        public IHttpActionResult GetAll()
        {
            try
            {
                CarroModel Carro = new CarroModel();

                return Ok(Carro.ListCarros());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                CarroModel Carros = new CarroModel();

                CarroDTO Carro = Carros.ListCarros(id).FirstOrDefault();
                if (Carro == null)
                {
                    return NotFound();
                } 
                else
                {
                    return Ok(Carro);
                }              
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }         
        }

        [HttpPost]
        public IHttpActionResult Insert(CarroDTO Carro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                CarroModel _Carro = new CarroModel();

                _Carro.Insert(Carro);

                return Ok(_Carro.ListCarros());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]CarroDTO Carro)
        {
            try
            {
                CarroModel _Carro = new CarroModel();
                Carro.Id = id;
                _Carro.Update(Carro);
                return Ok(_Carro.ListCarros(id).FirstOrDefault());
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CarroModel _Carro = new CarroModel();
                _Carro.Delete(id);
                return Ok("Deletado com sucesso");
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
