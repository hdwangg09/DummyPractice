using Microsoft.AspNetCore.Mvc;
using PracticeDummy.Models;

namespace PracticeDummy_API.Controllers
{
    [Route("master")]
    [ApiController]
    public class MasterAPI : Controller
    {
        private readonly Prn292Su171Context _context;
        public MasterAPI(Prn292Su171Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetListDummy()
        {
            var listMaster = _context.DummyMasters.ToList();
            return Ok(listMaster);
        }
    }
}
