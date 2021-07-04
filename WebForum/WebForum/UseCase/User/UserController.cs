

namespace WebForum.WebForumApi.UseCase.User
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class UserController : ControllerBase
    //{
    //    private readonly IAddUserUseCase addUserUseCase;
    //    private readonly IUserRemoveUseCase removeUserUseCase;
    //    private readonly IUpdateUserUseCase updateUserUseCase;
    //    private readonly IGetAllUserUseCase getAllUserUseCase;
    //    private readonly IGetByIdUserUseCase getByIdUserUseCase;
    //    private readonly IGetByNameUser getByNameUser;
    //    private readonly ITokenRepository tokenRepository;

    //    public UserController(
    //        IAddUserUseCase addUserUseCase,
    //        IUserRemoveUseCase removeUserUseCase,
    //        IUpdateUserUseCase updateUserUseCase,
    //        IGetAllUserUseCase getAllUserUseCase,
    //        IGetByIdUserUseCase getByIdUserUseCase,
    //        IGetByNameUser getByNameUser,
    //        ITokenRepository tokenRepository)
    //    {
    //        this.addUserUseCase = addUserUseCase;
    //        this.removeUserUseCase = removeUserUseCase;
    //        this.updateUserUseCase = updateUserUseCase;
    //        this.getAllUserUseCase = getAllUserUseCase;
    //        this.getByIdUserUseCase = getByIdUserUseCase;
    //        this.getByNameUser = getByNameUser;
    //        this.tokenRepository = tokenRepository;
    //    }

    //    /// <summary>
    //    /// Create a User
    //    /// </summary>
    //    /// <response code="200">User has been created. It returns a Guid</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpPost]
    //    [Route("CreateUser")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    [AllowAnonymous]
    //    public IActionResult CreateUser(string name, string email, string password)
    //    {
    //        var user = new Domain.Entities.User(name, email, password);

    //        var validationResult = new UserValidator().Validate(user);

    //        if (!validationResult.IsValid)
    //            return BadRequest(validationResult.Errors);

    //        addUserUseCase.Add(user);
    //        return new OkObjectResult(user);
    //    }
    //    /// <summary>
    //    /// Login a User
    //    /// </summary>
    //    /// <response code="200">User has been created. It returns a Guid</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpPost]
    //    [Route("LoginUser")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    [AllowAnonymous]
    //    public object LoginUser(string name, string password)
    //    {
    //        var user = tokenRepository.GetByName(name, password);
    //        return new OkObjectResult(user);
    //    }

    //    /// <summary>
    //    /// Get User Id
    //    /// </summary>
    //    /// <response code="200">Get User Id</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpPost]
    //    [Route("GetUserId")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    [Authorize("Bearer")]
    //    public IActionResult GetUserId(Guid id)
    //    {
    //        if (id == null)
    //        {
    //            return BadRequest();
    //        }
    //        var user = getByIdUserUseCase.GetById(id);
    //        return new OkObjectResult(user);
    //    }
    //    /// <summary>
    //    /// Get All Users
    //    /// </summary>
    //    /// <response code="200">Get All Users</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpPost]
    //    [Route("GetAllUser")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    //[Authorize("Bearer")]
    //    [AllowAnonymous]
    //    public IActionResult GetAllUser()
    //    {
    //        var topic = getAllUserUseCase.GetAll();

    //        return new OkObjectResult(topic);
    //    }
    //    /// <summary>
    //    /// Update a User
    //    /// </summary>
    //    /// <response code="200">User has been created. It returns the whole object</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpPut]
    //    [Route("UpdateUser")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    [Authorize("Bearer")]
    //    public IActionResult UpdateUser([FromBody]Guid id, string name)
    //    {
    //        var updateUser = getByIdUserUseCase.GetById(id);
    //        if (updateUser == null)
    //        {
    //            return BadRequest();
    //        }

    //        var user = new Domain.Entities.User(updateUser.Id, name, updateUser.Email, updateUser.Password, updateUser.CreatedAt);

    //        var validationResult = new UserValidator().Validate(user);

    //        if (!validationResult.IsValid)
    //            return BadRequest(validationResult.Errors);

    //        updateUserUseCase.Update(user);
    //        return new OkObjectResult(user);
    //    } /// <summary>
    //    /// Update a User
    //    /// </summary>
    //    /// <response code="200">User has been created. It returns the whole object</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpPut]
    //    [Route("UpdateUserType")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    [Authorize("Bearer")]
    //    public IActionResult UpdateUserType([FromBody]Guid id, int userType)
    //    {
    //        var updateUserType = getByIdUserUseCase.GetById(id);

    //        if (id == null)
    //        {
    //            return BadRequest();
    //        }

    //        var user = new Domain.Entities.User(updateUserType.Id, updateUserType.Name, updateUserType.Password, updateUserType.Email, updateUserType.CreatedAt, userType);

    //        updateUserUseCase.Update(user);
    //        return new OkObjectResult(user);
    //    }
    //    /// <summary>
    //    /// Delete a Topic
    //    /// </summary>
    //    /// <response code="200">Category has been created. It returns the whole object</response>
    //    /// <response code="400">Bad request.</response>
    //    [HttpDelete]
    //    [Route("RemoveUser")]
    //    [ProducesResponseType(typeof(Guid), 200)]
    //    [ProducesResponseType(typeof(ProblemDetails), 400)]
    //    [Authorize("Bearer")]
    //    public IActionResult RemoveUser([FromBody]Guid id)
    //    {
    //        if (getByIdUserUseCase.GetById(id) == null)
    //        {
    //            return BadRequest();
    //        }

    //        var user = getByIdUserUseCase.GetById(id);
    //        removeUserUseCase.Remove(user);
    //        return new OkObjectResult(user);
    //    }
    //}
}