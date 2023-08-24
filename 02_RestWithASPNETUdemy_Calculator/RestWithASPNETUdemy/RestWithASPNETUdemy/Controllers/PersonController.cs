using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //todos os endpoints iniciarao com /aPI
    public class PersonController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }
        //rotas
        [HttpGet] //<-- ENDPOINT
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")] //<-- ENDPOINT
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost] //<-- ENDPOINT
        public IActionResult Post([FromBody] Person person) // poderia ser o create
        {
            
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Create(person));
        }

        [HttpPut] //<-- ENDPOINT
        public IActionResult Put([FromBody] Person person) //poderia ser o update
        {

            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")] //<-- ENDPOINT
        public IActionResult Delete(long id)
        {
           _personService.Delete(id);
            return NoContent();
        }



        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;


            //throw new NotImplementedException();
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strNumber,out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

       
    }
}