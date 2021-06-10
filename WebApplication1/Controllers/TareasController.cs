using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DATA;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controlador de Tareas
    /// </summary>
    /// <remarks>
    /// Controller que contiene todos los metodos del WebApi
    /// </remarks>
    public class TareasController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// Devuelve una lista de las tareas de todos los usuarios
        /// </summary>
        /// <remarks>
        /// Se enlista todas las tareas si ningun tipo de condicion
        /// </remarks>
        /// <response code="200">True. Devuelve el objeto solicitado.</response>
        public List<Tareas> Get()
        {
            return TareasData.Listar();
        }

        // GET api/<controller>/5
        /// <summary>
        /// Devuelve la info de una sola tarea especifica
        /// </summary>
        /// <remarks>
        /// Devuelve la info de una tarea especifica, recibe como parametro el Id de la tarea
        /// </remarks> 
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">True. Devuelve el objeto solicitado.</response>
        public Tareas Get(int id)
        {
            return TareasData.ObtenerById(id);
        }

        // POST api/<controller>/fechVence
        //public List<Tareas> ObtenerByFilter([FromBody] Tareas oTareas)
        //{
        //    return TareasData.ObtenerByFilter();
        //}

        // POST api/<controller>
        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <remarks>
        /// Crea una nueva tarea, enviandole como parametro el objecto json 
        /// </remarks>
        /// <param name="oTareas">Objeto que envia los datos y los graba a la BD.</param>
        /// <response code="200">TRUE. Devuelve el objeto solicitado.</response>
        public bool Post([FromBody] Tareas oTareas)
        {
            return TareasData.Registrar(oTareas);
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Modifica una tarea especifica.
        /// </summary>
        /// <remarks>
        /// Modifica una tarea especifica, enviandole como parametro el objecto json con los campos IDTarea y AutorTarea 
        /// </remarks>
        /// <param name="oTareas">Objeto que envia los datos y modifica la info a la BD.</param>
        /// <response code="200">TRUE. Devuelve el objeto solicitado.</response>
        public bool Put([FromBody] Tareas oTareas)
        {
            return TareasData.Modificar(oTareas);
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Elimina una tarea especifica.
        /// </summary>
        /// <remarks>
        /// Elimina una tarea especifica, enviandole como parametro el objecto json con los campos IDTarea y AutorTarea 
        /// </remarks>
        /// <param name="oTareas">Objeto que envia para eliminar el registro a la BD.</param>
        /// <response code="200">TRUE. Devuelve el objeto solicitado.</response>
        public bool Delete([FromBody] Tareas oTareas)
        {
            return TareasData.Eliminar(oTareas);
        }
    }
}
