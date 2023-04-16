namespace MoqItIsEquivalentTo;

public interface IConcatenatorService
{
    string ConcatenateIdAndName(SampleModel model);
    string ConcatenateIdAndDescription(SampleModel model);
    string ConcatenateAllIdsAndNames(IEnumerable<SampleModel> models);
    string ConcatenateAllIdsAndDescriptions(IEnumerable<SampleModel> models);
}

