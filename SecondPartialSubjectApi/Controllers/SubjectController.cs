using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace FirstPartialAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This is the route
    public class SubjectController : Controller
    {
        /*private string ConnectionString = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";*/
        private SubjectService subjectService;
        private IConfiguration configuration;

        /*public SubjectController()*/
        public SubjectController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.subjectService = new SubjectService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ListarCliente")]
        // Get all the subjects
        public ActionResult<List<SubjectModel>> read()
        {
            var resultado = subjectService.read();
            return Ok(resultado);
        }

        [HttpGet("ConsultarCliente/{id}")]
        /*public ActionResult<SubjectModel> getById(int id, string documento)*/
        public ActionResult<SubjectModel> getById(int id)
        {
            var result = this.subjectService.getByid(id);
            return Ok(result);
        }

        [HttpPost("InsertarCliente")]
        public ActionResult<string> insert(SubjectModel models)
        {
            /*return Ok("Ok");*/
            var result = this.subjectService.insert(new Infraestructure.Models.SubjectModel
            {
                Name = models.Name,
                LastName = models.LastName,
                Email = models.Email,
                address = models.address,
                Telephone = models.Telephone,
                document = models.document,
                Document_Type = models.Document_Type,
                Status = models.Status,
            });
            return Ok(result);
        }
        // endpoint for subject modify
        [HttpPut("ModificarCliente/{id}")]
        public ActionResult<string> modify(SubjectModel models, int id)
        {
            var result = this.subjectService.modify(new Infraestructure.Models.SubjectModel
            {
                Name = models.Name,
                LastName = models.LastName,
                Email = models.Email,
                address = models.address,
                Telephone = models.Telephone,
                document = models.document,
                Document_Type = models.Document_Type,
                Status = models.Status,
            }, id);
            return Ok(result);
        }

        // endpoint for subject delete
        [HttpDelete("EliminarCliente/{id}")]
        public ActionResult<string> delete(int id)
        {
            var result = this.subjectService.delete(id);
            return Ok(result);
        }



    }
}
