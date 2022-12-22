using CnpjExt.ViewModel;
using Ext.Net;
using Ext.Net.MVC;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CnpjExt.Controllers
{
    public class CnpjController : Controller
    {
        protected string ApiReceita = System.Configuration.ConfigurationManager.AppSettings["ApiReceita"];

        public ActionResult Index() => View();

        // GET: Cnpj
        [DirectMethod]
        public async Task<ActionResult> Buscar(string cnpj)
        {
            CnpjViewModel resultado = new CnpjViewModel();

            cnpj = cnpj.Replace("/", "").Replace(".", "").Replace("_", "").Replace("-", "").Trim();

            if (string.IsNullOrEmpty(cnpj))
            {
                return this.Direct(false, "Digite o CNPJ!");
            }

            if (cnpj.Length < 14)
            {
                return this.Direct(false, "O CNPJ deverá conter no minimo 14 caracteres!");
            }

            if (cnpj.Length > 18)
            {
                return this.Direct(false, "O CNPJ deverá conter no máximo 18 caracteres!");
            }

            string postCnpj = string.Format("{0}/{1}", ApiReceita, cnpj);

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(resultado),
                                                     Encoding.UTF8, "application/json");
                using (var response = await httpClient.GetAsync(postCnpj))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    resultado = JsonConvert.DeserializeObject<CnpjViewModel>(apiResponse);

                    if (!string.IsNullOrEmpty(resultado.Message))
                    {
                        return this.Direct(false, resultado.Message);
                    }
                }
            }
            return this.Direct(resultado);
        }
    }
}





