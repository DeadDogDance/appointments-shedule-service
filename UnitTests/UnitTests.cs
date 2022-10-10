using domain.Interactors;
using domain.Adaptors;
using Moq;
using Xunit;
using domain.Entities;

namespace UnitTests;

public class UserTests
{
    private readonly UserInteractor _userInteractor;
    private readonly Mock<IUserAdaptor> _userAdaptorMock;

    public UserTests()
    {
        _userAdaptorMock = new Mock<IUserAdaptor>();
        _userInteractor = new UserInteractor(_userAdaptorMock.Object);
    }

    [Fact]
    public void GetUserByLoginEmptyLogin_ShouldFail()
    {
        var res = _userInteractor.GetUserByLogin(string.Empty);

        Assert.True(res.IsFailure);
        Assert.Equal("Empty login", res.Error);
    }


    [Fact]
    public void GetUserByLoginUserNotFound_ShouldFail()
    {
        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => null);

        var res = _userInteractor.GetUserByLogin("qwertyuiop");

        Assert.True(res.IsFailure);
        Assert.Equal("User not found", res.Error);
    }

    [Fact]
    public void GetUserByLoginUserFound_ShouldOk()
    {
        string login = "Amongus";
        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => new User(default,login,"","","",default));

        var res = _userInteractor.GetUserByLogin(login);

        Assert.True(res.Success);
        Assert.Equal(login, res.Value.Login);
    }

    [Fact]
    public void CheckUserEmptyLoginAndPassowrd_ShouldFail()
    {
        var res = _userInteractor.CheckUser(string.Empty, string.Empty);

        Assert.True(res.IsFailure);
        Assert.Equal("Empty login", res.Error);
    }

    [Fact]
    public void CheckUserEmptyLogin_ShouldFail()
    {
        var res = _userInteractor.CheckUser(string.Empty, "Amongus");

        Assert.True(res.IsFailure);
        Assert.Equal("Empty login", res.Error);
    }

    [Fact]
    public void CheckUserEmptyPassword_ShouldFail()
    {
        var res = _userInteractor.CheckUser("Amongus", string.Empty);

        Assert.True(res.IsFailure);
        Assert.Equal("Empty password", res.Error);
    }

    [Fact]
    public void CheckUserUserNotFoundShouldFail()
    {
        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => null);

        var res = _userInteractor.CheckUser("Amongus", "1");

        Assert.True(res.IsFailure);
        Assert.Equal("User not found", res.Error);
    }

    [Fact]
    public void CheckUserPasswordDontMatch_ShouldFail()
    {
        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => new User(default,"Amongus","2","","",default));

        var res = _userInteractor.CheckUser("Amongus", "1");

        Assert.True(res.IsFailure);
        Assert.Equal("Password don't match", res.Error);
    }

    [Fact]
    public void CheckUser_ShouldOk()
    {
        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => new User(default, "Amongus", "1", "", "", default));

        var res = _userInteractor.CheckUser("Amongus", "1");

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void CreateUserNoData_ShouldFail()
    {
        var res = _userInteractor.CreateUser(new User(default, "", "", "", "", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty login", res.Error);
    }

    [Fact]
    public void CreateUserEmptyPassword_ShouldFail()
    {
        var res = _userInteractor.CreateUser(new User(default, "Amongus", "", "", "", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty password", res.Error);
    }

    [Fact]
    public void CreateUserEmptyPhoneNumber_ShouldFail()
    {
        var res = _userInteractor.CreateUser(new User(default, "Amongus", "amongus", "", "", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty phone number", res.Error);
    }

    [Fact]
    public void CreateUserEmptyName_ShouldFail()
    {
        var res = _userInteractor.CreateUser(new User(default, "Amongus", "amongus", "88888888", "", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty name", res.Error);
    }

    [Fact]
    public void CreateUserLoginTaken_ShouldFail()
    {
        string login = "Amongus";

        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => new User(default, login, "1", "", "", default));

        var res = _userInteractor.CreateUser(new User(default, login, "amongus", "88888888", "Sussy Man", default));

        Assert.True(res.IsFailure);
        Assert.Equal("Login already taken", res.Error);
    }

    [Fact]
    public void CreateUser_ShouldOk()
    {
        string login = "Amongus";

        _userAdaptorMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>()))
                    .Returns(() => null);

        var res = _userInteractor.CreateUser(new User(default, "AnotherLogin", "amongus", "88888888", "Sussy Man", default));

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }
}