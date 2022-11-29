using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoCDBController : ControllerBase
    {
        private readonly ILogger<CalculoCDBController> _logger;

        public CalculoCDBController(ILogger<CalculoCDBController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "CalculaCDB")]
        public double CalculaCDB(double vali, int prazo)
        {
            var resultado = 0.00;
            var imposto = 0.00;
            if (vali >= 0 && prazo > 1)
            {
                if (prazo <= 6)
                    imposto = 0.225;
                if (prazo > 6 && prazo <= 12)
                    imposto = 0.2;
                if (prazo > 12 && prazo <= 24)
                    imposto = 0.175;
                if (prazo > 24)
                    imposto = 0.15;

                resultado = vali * (prazo + (0.009 * 1.08));
                return resultado * imposto;
            }
            else
            {
                return resultado;
            }
        }
    }
}
