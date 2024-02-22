using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeDummy.Models;

namespace PracticeDummy.Controllers
{
    [Route("dummy")]
    [ApiController]
    public class DummyAPI : ControllerBase
    {
        private readonly Prn292Su171Context _context;
        public DummyAPI(Prn292Su171Context context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public ActionResult GetListDummy(string? dummyName, string? masterID)
        {
            var listDumm = _context.DummyDetails
                .Select(dummy => new
                {
                    dummy.DetailId,
                    dummy.DetailName,
                    dummy.MasterId,
                    MasterName = dummy.Master.MasterName
                });
            if (!string.IsNullOrEmpty(dummyName))
            {
                listDumm = listDumm.Where(dm => dm.MasterName.Contains(dummyName));
            }
            if (!string.IsNullOrEmpty(masterID))
            {
                int masterIdReq = int.Parse(masterID);
                if (masterIdReq > 0)
                {
                    listDumm = listDumm.Where(dm => dm.MasterId == masterIdReq);
                }
            }
            return Ok(listDumm.ToList());
        }

    }
}
