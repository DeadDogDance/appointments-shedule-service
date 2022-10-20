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
        DateTime startTime = new DateTime(1, 1, 1, 1, 0, 0);
        DateTime endTime = new DateTime(1, 1, 1, 1, 0, 1);

        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(startTime,endTime))
                    .Returns(() => null);

        var res = _appointmentInteractor.SaveAppointment(startTime,endTime);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not save appointment", res.Error);
    }

    public void SaveAppointmentToAnyDoctorEndBeforeStart_ShouldFail()
    {
        DateTime startTime = new DateTime(1, 1, 1, 1, 0, 1);
        DateTime endTime = new DateTime(1, 1, 1, 1, 0, 0);

        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(startTime, endTime))
                    .Returns(() => null);

        var res = _appointmentInteractor.SaveAppointment(startTime, endTime);

        Assert.True(res.IsFailure);
        Assert.Equal("End of appointment should be after the start", res.Error);
    }

    [Fact]
    public void SaveAppointmentToAnyDoctor_ShouldOk()
    {
        DateTime startTime = new DateTime(1, 1, 1, 1, 0, 0);
        DateTime endTime = new DateTime(1, 1, 1, 1, 0, 1);

        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(startTime, endTime))
                    .Returns(() => new Appointment(startTime, endTime, default, default));

        var res = _appointmentInteractor.SaveAppointment(startTime, endTime);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void SaveAppointmentToSpecificDoctor_ShouldFail()
    {
        DateTime startTime = new DateTime(1, 1, 1, 1, 0, 0);
        DateTime endTime = new DateTime(1, 1, 1, 1, 0, 1);
        Doctor doctor = new Doctor(default,"",default);

        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(startTime, endTime, doctor))
                    .Returns(() => null);

        var res = _appointmentInteractor.SaveAppointment(startTime, endTime, doctor);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not save appointment", res.Error);
    }

    [Fact]
    public void SaveAppointmentToSpecificDoctorEndBeforeStart_ShouldFail()
    {
        DateTime startTime = new DateTime(1, 1, 1, 1, 0, 1);
        DateTime endTime = new DateTime(1, 1, 1, 1, 0, 0);
        Doctor doctor = new Doctor(default, "", default);

        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(startTime, endTime, doctor))
                    .Returns(() => null);

        var res = _appointmentInteractor.SaveAppointment(startTime, endTime, doctor);

        Assert.True(res.IsFailure);
        Assert.Equal("End of appointment should be after the start", res.Error);
    }

    [Fact]
    public void SaveAppointmentToSpecificDoctor_ShouldOk()
    {
        DateTime startTime = new DateTime(1, 1, 1, 1, 0, 0);
        DateTime endTime = new DateTime(1, 1, 1, 1, 0, 1);
        Doctor doctor = new Doctor(default, "", default);

        _appointmentAdaptorMock.Setup(repository => repository.SaveAppointment(startTime, endTime, doctor))
                    .Returns(() => new Appointment(startTime, endTime, default, default));

        var res = _appointmentInteractor.SaveAppointment(startTime, endTime, doctor);

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