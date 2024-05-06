using Microsoft.AspNetCore.Mvc;

namespace WebPatient.Controllers
{
    [Route("api/[controller]")]
    public class WebApi : ControllerBase
    {
        private static List<Patient> _patients = new List<Patient>();

        // POST: api/patient/Create
        [HttpPost("Create")]
        public IActionResult Create([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest("Invalid data");

            _patients.Add(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

        // GET: api/patient/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<Patient> GetAll()
        {
            return _patients;
        }

        // GET: api/patient/GetById/{id}
        [HttpGet("GetById/{id}")]
        public IActionResult GetPatientById(Guid id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        // PUT: api/patient/Update/{id}
        [HttpPut("Update/{id}")]
        public IActionResult UpdatePatient(Guid id, [FromBody] Patient updatedPatient)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound();

            patient.Nome = updatedPatient.Nome;
            patient.Sobrenome = updatedPatient.Sobrenome;
            patient.Sexo = updatedPatient.Sexo;
            patient.Nascimento = updatedPatient.Nascimento;
            patient.Altura = updatedPatient.Altura;
            patient.Peso = updatedPatient.Peso;
            patient.Cpf = updatedPatient.Cpf;

            return NoContent();
        }

        // DELETE: api/patient/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public IActionResult DeletePatient(Guid id)
        {
            var patient = _patients.FirstOrDefault(p => p.Id == id);
            if (patient == null)
                return NotFound();

            _patients.Remove(patient);
            return NoContent();
        }

    }
}
