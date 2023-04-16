namespace MoqItIsEquivalentTo;

public class SampleService
{
    private readonly IConcatenatorService _concatenatorService;

    public SampleService(IConcatenatorService concatenatorService)
    {
        _concatenatorService = concatenatorService;
    }

    public string ConcatenatedValue(SampleModel model)
    {
        if (model.Id % 2 == 0)
        {
            return _concatenatorService.ConcatenateIdAndName(model);
        }
        else
        {
            return _concatenatorService.ConcatenateIdAndDescription(model);
        }
    }

    public string ConcatenateAllValues(IEnumerable<SampleModel> models)
    {
        if (models.FirstOrDefault()?.Id % 2 == 0)
        {
            return _concatenatorService.ConcatenateAllIdsAndNames(models);
        }
        else
        {
            return _concatenatorService.ConcatenateAllIdsAndDescriptions(models);
        }
    }
}
