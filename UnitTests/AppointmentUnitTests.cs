using domain.Interactors;
using domain.Adaptors;
using Moq;
using Xunit;
using domain.Entities;

namespace UnitTests;
public class AppointmentUnitTests
{
    private readonly AppointmentInteractor _appointmentInteractor;
    private readonly Mock<IAppointmentAdaptor> _appointmentAdaptorMock;

    public AppointmentUnitTests()
    {
        _appointmentAdaptorMock = new Mock<IAppointmentAdaptor>();
        _appointmentInteractor = new AppointmentInteractor(_appointmentAdaptorMock.Object);
    }

    [Fact]
    public void SaveAppointmentToAnyDoctor_ShouldFail()
    {
        DateOnly date = new DateOnly(1, 1, 1);
        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(date))
                    .Returns(() => null);

        var res = _appointmentInteractor.SaveAppointment(date);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not save appointment", res.Error);
    }

    [Fact]
    public void SaveAppointmentToAnyDoctor_ShouldOk()
    {
        DateOnly date = new DateOnly(1, 1, 1);
        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(date))
                    .Returns(() => new Appointment(date, new DateTime(1,1,1), new DateTime(1,1,1), default, default));

        var res = _appointmentInteractor.SaveAppointment(date);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    public void SaveAppointmentToSpecificDoctor_ShouldFail()
    {
        DateOnly date = new DateOnly(1, 1, 1);
        Doctor doctor = new Doctor(default,"",default);
        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(date, doctor))
                    .Returns(() => null);

        var res = _appointmentInteractor.SaveAppointment(date, doctor);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not save appointment", res.Error);
    }

    [Fact]
    public void SaveAppointmentToSpecificDoctor_ShouldOk()
    {
        DateOnly date = new DateOnly(1, 1, 1);
        Doctor doctor = new Doctor(default, "", default);
        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(date, doctor))
                    .Returns(() => new Appointment(date, new DateTime(1, 1, 1), new DateTime(1, 1, 1), default, default));

        var res = _appointmentInteractor.SaveAppointment(date, doctor);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void GetFreeAppointmentDateList_ShouldFail()
    {
        Specialization specialization = new Specialization(default, " ");
        _appointmentAdaptorMock.Setup(repository => repository.GetFreeAppointmentDateList(specialization))
                    .Returns(() => null);

        var res = _appointmentInteractor.GetFreeAppointmentDateList(specialization);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not get date list", res.Error);
    }

    [Fact]
    public void GetFreeAppointmentDateList_ShouldOk()
    {
        Specialization specialization = new Specialization(default, " ");
        _appointmentAdaptorMock.Setup(repository => repository.GetFreeAppointmentDateList(specialization))
                    .Returns(() => new List<DateOnly>());

        var res = _appointmentInteractor.GetFreeAppointmentDateList(specialization);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }
}