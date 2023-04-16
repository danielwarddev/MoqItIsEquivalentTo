using FluentAssertions;
using Moq;
using MoqItIsEquivalentTo;

namespace MoqItIsEquivalentToUnitTests;

public class SampleServiceTests
{
    private readonly Mock<IConcatenatorService> _concatenatorService = new();
    private readonly SampleService _sampleService;

    public SampleServiceTests()
    {
        _sampleService = new SampleService(_concatenatorService.Object);
    }

    [Fact]
    public void When_Id_Is_Not_Divisible_By_2_Then_Concatenates_Id_And_Description()
    {
        var model = new SampleModel(1, "cool name", "neat description");
        var expectedValue = "expected";
        _concatenatorService.Setup(x => x.ConcatenateIdAndDescription(ItIs.EquivalentTo(model))).Returns(expectedValue);

        var value = _sampleService.ConcatenatedValue(model);

        value.Should().Be(expectedValue);
    }

    [Fact]
    public void When_Id_Is_Divisible_By_2_Then_Concatenates_Id_And_Name()
    {
        var model = new SampleModel(2, "cool name", "neat description");
        var expectedValue = "expected";
        _concatenatorService.Setup(x => x.ConcatenateIdAndName(ItIs.EquivalentTo(model))).Returns(expectedValue);

        var value = _sampleService.ConcatenatedValue(model);

        value.Should().Be(expectedValue);
    }

    [Fact]
    public void When_First_Items_Id_Is_Not_Divisible_By_2_Then_Concatenates_All_Id_And_Descriptions()
    {
        var models = new List<SampleModel>()
        {
            new SampleModel(1, "name1", "description1"),
            new SampleModel(2, "name2", "description2"),
            new SampleModel(3, "name3", "description3")
        };
        var expectedValue = "expected";
        _concatenatorService.Setup(x => x.ConcatenateAllIdsAndDescriptions(ItIs.EquivalentTo(models))).Returns(expectedValue);

        var value = _sampleService.ConcatenateAllValues(models);

        value.Should().Be(expectedValue);
    }

    [Fact]
    public void When_First_Items_Id_Is_Divisible_By_2_Then_Concatenates_All_Id_And_Names()
    {
        var models = new List<SampleModel>()
        {
            new SampleModel(2, "name2", "description2"),
            new SampleModel(1, "name1", "description1"),
            new SampleModel(3, "name3", "description3")
        };
        var expectedValue = "expected";
        _concatenatorService.Setup(x => x.ConcatenateAllIdsAndNames(ItIs.EquivalentTo(models))).Returns(expectedValue);

        var value = _sampleService.ConcatenateAllValues(models);

        value.Should().Be(expectedValue);
    }
}