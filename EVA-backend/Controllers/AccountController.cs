using EVA_backend.DataLayer;
using EVA_backend.Entities;
using EVA_backend.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using System.Web.Http;

[RoutePrefix("api/Account")]
public class AccountController : ApiController
{
    private AuthRepository _repo = null;
    private AuthContext _ctx = null;
    private UserManager<UserModel> _userManager = null;

    public AccountController()
    {
        _repo = new AuthRepository();
        _ctx = new AuthContext();

        UserStore<UserModel> userStore = new UserStore<UserModel>(_ctx);
        _userManager = new UserManager<UserModel>(userStore);
    }

    // POST api/Account/Register
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IHttpActionResult> Register(UserModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        IdentityResult result = await _repo.RegisterUser(userModel);

        IHttpActionResult errorResult = GetErrorResult(result);

        if (errorResult != null)
        {
            return errorResult;
        }

        return Ok();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _repo.Dispose();
        }

        base.Dispose(disposing);
    }

    private IHttpActionResult GetErrorResult(IdentityResult result)
    {
        if (result == null)
        {
            return InternalServerError();
        }

        if (!result.Succeeded)
        {
            if (result.Errors != null)
            {
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return BadRequest();
            }

            return BadRequest(ModelState);
        }

        return null;
    }
}