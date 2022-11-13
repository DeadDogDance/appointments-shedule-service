using domain.Interactors;
using domain.Adaptors;
using Moq;
using Xunit;
using domain.Entities;

namespace UnitTests;

public class DoctorTests
{
    private readonly DoctorInteractor _doctorInteractor;
    private readonly Mock<IDoctorAdapter> _doctorAdaptorMock;
        
    public DoctorTests()
    {
        _doctorAdaptorMock = new Mock<IDoctorAdapter>();
        _doctorInteractor = new DoctorInteractor(_doctorAdaptorMock.Object);
    }

    [Fact]
    public void GetDoctorNotByIdFound_ShouldFail()
    {
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(It.IsAny<int>()))
            .Returns(() => null);

        var res = _doctorInteractor.GetDoctor(1);

        Assert.True(res.IsFailure);
        Assert.Equal("Doctor not found" ,res.Error);
    }

    [Fact]
    public void GetDoctorById_ShouldOk()
    {
        int id = 1;
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(It.IsAny<int>()))
            .Returns(() => new Doctor(id,"",default));

        var res = _doctorInteractor.GetDoctor(id);

        Assert.True(res.Success);
        Assert.Equal(id, res.Value.DoctorId);
    }

    [Fact]
    public void GetDoctorsBySpec_ShouldFail()
    {
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(It.IsAny<Specialization>()))
            .Returns(() => null);

        var res = _doctorInteractor.GetDoctor(new Specialization(default, "Name"));

        Assert.True(res.IsFailure);
        Assert.Equal("Can not get list of doctors", res.Error);
    }

    [Fact]
    public void GetDoctorsBySpecNullSpec_ShouldFail()
    {
        var res = _doctorInteractor.GetDoctor(new Specialization(default, ""));

        Assert.True(res.IsFailure);
        Assert.Equal("Empty specialization", res.Error);
    }

    [Fact]
    public void GetDoctorsBySpec_ShouldOk()
    {
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(It.IsAny<Specialization>()))
            .Returns(() => new List<Doctor> ());

        var res = _doctorInteractor.GetDoctor(new Specialization(default, "Amongus"));

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void GetDoctorList_ShouldFail()
    {
        _doctorAdaptorMock.Setup(repository => repository.GetDoctorList())
            .Returns(() => null);

        var res = _doctorInteractor.GetDoctorList();

        Assert.True(res.IsFailure);
        Assert.Equal("Can not get list of doctors", res.Error);
    }

    [Fact]
    public void GetDoctorList_ShouldOk()
    {
        _doctorAdaptorMock.Setup(repository => repository.GetDoctorList())
            .Returns(() => new List<Doctor>());

        var res = _doctorInteractor.GetDoctorList();

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void DeleteDoctorEntityNotFound_ShouldFail()
    {
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(It.IsAny<int>()))
            .Returns(() => null);

        var res = _doctorInteractor.DeleteDoctor(1);

        Assert.True(res.IsFailure);
        Assert.Equal("Doctor not found", res.Error);
    }

    [Fact]
    public void DeleteDoctorNotDelete_ShouldFail()
    {
        int id = 1;
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(id))
            .Returns(() => new Doctor(id, "Amongus", default));

        _doctorAdaptorMock.Setup(repository => repository.DeleteDoctor(It.IsAny<int>()))
            .Returns(() => false);

        var res = _doctorInteractor.DeleteDoctor(id);

        Assert.True(res.IsFailure);
        Assert.Equal("Doctor not deleted", res.Error);
    }

    [Fact]
    public void DeleteDoctorHaveAppointments_ShouldFail()
    {
        int id = 1;
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(id))
            .Returns(() => new Doctor(id, "Amongus", default));
        _doctorAdaptorMock.Setup(repository => repository.HaveAppointmens(id))
            .Returns(() => true);
        _doctorAdaptorMock.Setup(repository => repository.DeleteDoctor(It.IsAny<int>()))
            .Returns(() => false);

        var res = _doctorInteractor.DeleteDoctor(id);

        Assert.True(res.IsFailure);
        Assert.Equal("Doctor have appointments", res.Error);
    }

    [Fact]
    public void DeleteDoctor_ShouldOk()
    {
        int id = 1;
        _doctorAdaptorMock.Setup(repository => repository.GetDoctor(id))
            .Returns(() => new Doctor(id,"Amongus",default));
        _doctorAdaptorMock.Setup(repository => repository.HaveAppointmens(id))
            .Returns(() => false);
        _doctorAdaptorMock.Setup(repository => repository.DeleteDoctor(It.IsAny<int>()))
            .Returns(() => true);

        var res = _doctorInteractor.DeleteDoctor(id);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void CreateDoctorEmptyName_ShouldFail()
    {
        var res = _doctorInteractor.CreateDoctor(default, "", default);

        Assert.True(res.IsFailure);
        Assert.Equal("Empty doctor name", res.Error);
    }

    [Fact]
    public void CreateDoctor_ShouldOk()
    {
        var res = _doctorInteractor.CreateDoctor(default, "Amongus", new Specialization(10, " "));

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }
}