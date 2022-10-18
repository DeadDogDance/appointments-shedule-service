using domain.Interactors;
using domain.Adaptors;
using Moq;
using Xunit;
using domain.Entities;

namespace UnitTests;

public class ScheduleUnitTests
{
    private readonly ScheduleInteractor _scheduleInteractor;
    private readonly Mock<IScheduleAdaptor> _scheduleAdaptorMock;

    public ScheduleUnitTests()
    {
        _scheduleAdaptorMock = new Mock<IScheduleAdaptor>();
        _scheduleInteractor = new ScheduleInteractor(_scheduleAdaptorMock.Object);
    }

    [Fact]
    public void GetDoctorScheduleByDate_ShouldFail()
    {
        Doctor doctor = new Doctor(default, " ", default);
        DateOnly date = new DateOnly(1, 1, 1);

        _scheduleAdaptorMock.Setup(repository => repository.GetDoctorScheduleByDate(doctor, date))
            .Returns(() => null);

        var res = _scheduleInteractor.GetDoctorScheduleByDate(doctor, date);

        Assert.True(res.IsFailure);
        Assert.Equal("Schedule not found", res.Error);
    }

    [Fact]
    public void GetDoctorScheduleByDate_ShouldOk()
    {
        Doctor doctor = new Doctor(default, " ", default);
        DateOnly date = new DateOnly(1, 1, 1);

        _scheduleAdaptorMock.Setup(repository => repository.GetDoctorScheduleByDate(doctor, date))
            .Returns(() => new Schedule(default,new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

        var res = _scheduleInteractor.GetDoctorScheduleByDate(doctor, date);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void AddSchedule_ShouldFail()
    {
        Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

        _scheduleAdaptorMock.Setup(repository => repository.AddSchedule(schedule))
            .Returns(() => null);

        var res = _scheduleInteractor.AddSchedule(schedule);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not add schedule", res.Error);
    }

    [Fact]
    public void AddSchedule_ShouldOk()
    {
        Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

        _scheduleAdaptorMock.Setup(repository => repository.AddSchedule(schedule))
            .Returns(() => new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

        var res = _scheduleInteractor.AddSchedule(schedule);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }

    [Fact]
    public void EditSchedule_ShouldFail()
    {
        Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

        _scheduleAdaptorMock.Setup(repository => repository.EditSchedule(schedule))
            .Returns(() => null);

        var res = _scheduleInteractor.EditSchedule(schedule);

        Assert.True(res.IsFailure);
        Assert.Equal("Can not edit schedule", res.Error);
    }

    [Fact]
    public void EditSchedule_ShouldOk()
    {
        Schedule schedule = new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1));

        _scheduleAdaptorMock.Setup(repository => repository.EditSchedule(schedule))
            .Returns(() => new Schedule(default, new DateTime(1, 1, 1), new DateTime(1, 1, 1)));

        var res = _scheduleInteractor.EditSchedule(schedule);

        Assert.True(res.Success);
        Assert.Equal(string.Empty, res.Error);
    }
}

