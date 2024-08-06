using App.com.crcind.www;
using System.Threading.Tasks;


public class SOAPCustomerService
{
    private readonly SOAPDemo _soapClient;

    public SOAPCustomerService()
    {
        _soapClient = new SOAPDemo();
    }

    public async Task<App.Person> FindPersonAsync(string id)
    {

        var soapResponse = await Task.Run(() => {
            return _soapClient.FindPerson(id);
        });

        return ConvertToPerson(soapResponse);
    }

    private App.Person ConvertToPerson(App.com.crcind.www.Person soapPerson)
    {
        if (soapPerson == null)
        {
            return null;
        }

        return new App.Person
        {
            Name = soapPerson.Name,
            SSN = soapPerson.SSN,
            DOB = soapPerson.DOB.ToString("yyyy-MM-dd"), 
            Age = (int)soapPerson.Age
        };
    }
}

