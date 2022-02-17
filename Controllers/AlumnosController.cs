using Examen2.Entities;
using Examen2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        public readonly AlumnoDbContext _context;

        AlumnoItem _oAlumnoItem = new AlumnoItem();
        private readonly ILogger<WeatherForecastController> _logger;
        public AlumnosController(AlumnoDbContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }


        // GET: api/<AlumnosController>
        [HttpGet]
        public IEnumerable<AlumnoItem> Get()
        {
            _logger.LogWarning("Before - Lista de Alumnos");
            _logger.LogInformation("Prueba - Information");
            List<AlumnoItem> alumnos = _context.AlumnoItems.ToList();
            _logger.LogWarning("After - Lista de Alumnos");
            return alumnos;
        }

        // GET api/<AlumnosController>/5
        [HttpGet("{id}")]
        public AlumnoItem Get(int id)
        {
            var alumnoBD = _context.AlumnoItems.Where(x => x.Id == id).FirstOrDefault();
            return alumnoBD;
        }

        //POST api/<AlumnosController>
        [HttpPost]
        //public void Post(int id, [FromBody] AlumnoItem alumno)
        public async Task<AlumnoItem> Post(int id, [FromBody] AlumnoItem oAlumnoItem)
        {
            _oAlumnoItem = new AlumnoItem();
            if (id == 0)
            {
                _context.AlumnoItems.Add(oAlumnoItem);
                _context.SaveChanges();
            }
            else
            {
                oAlumnoItem.Id = id;
                _context.AlumnoItems.Update(oAlumnoItem);
                _context.SaveChanges();
            }
            await _context.SaveChangesAsync();

            return _oAlumnoItem;
        }

        // POST api/<StudentsController>
        //[HttpPost]
        //public async Task<AlumnoItem> Post([FromBody] AlumnoItem oAlumno)
        //{
        //    return await _context.AddOrUpdate(oAlumno);
        //}

        // PUT api/<AlumnosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AlumnoItem alumno)
        {
            //var alumnoBD = _context.AlumnoItems.Where(x => x.Id == alumno.Id).FirstOrDefault();
            //alumnoBD.Email = alumno.Email;
            //alumnoBD.Nombre = alumno.Nombre;
            //alumnoBD.Phone = alumno.Phone;
            //alumnoBD.Status = alumno.Status;
            //_context.AlumnoItems.Update(alumnoBD);
            //_context.SaveChanges();

            alumno.Id = id;
            _context.AlumnoItems.Update(alumno);
            _context.SaveChanges();
        }

        // DELETE api/<AlumnosController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            string message = "";
            var alum = _context.AlumnoItems.Where(x => x.Id == id).FirstOrDefault();
            _context.AlumnoItems.Remove(alum);
            _context.SaveChanges();

            int rep = await _context.SaveChangesAsync();
            message = rep.ToString();
            return message;
        }

    }
}
