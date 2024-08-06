using System;
using System.Threading.Tasks;
using System.Web.Http;

public class SoapClientController : ApiController
{
    private readonly SOAPCustomerService _soapService;

    public SoapClientController()
    {
        _soapService = new SOAPCustomerService();
    }

    [HttpGet]
    [Route("api/soapclient/find/{id}")]
    public async Task<IHttpActionResult> FindCustomer(string id)
    {
        try
        {
            var person = await _soapService.FindPersonAsync(id);

            if (person != null)
            {
                
                string dobFormatted = string.Empty;
                if (DateTime.TryParse(person.DOB, out DateTime dob))
                {
                    dobFormatted = dob.ToString("yyyy-MM-dd");
                }
                else
                {
                    dobFormatted = "Nepoznat datum"; 
                }

                return Ok(new
                {
                    Name = person.Name,
                    SSN = person.SSN,
                    DOB = dobFormatted,
                    Age = person.Age
                });
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}


