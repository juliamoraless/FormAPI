using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Infra.Context;
using FormContext = Infra.Context.FormContext;
namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class FormController: ControllerBase
    {
        private readonly FormContext _context;
  
        public FormController(FormContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var forms = _context.Forms.ToList();
            return Ok(forms);
        }
    
    }
