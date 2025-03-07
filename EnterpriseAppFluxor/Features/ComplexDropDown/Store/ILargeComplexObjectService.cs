namespace EnterpriseAppFluxor.Features.ComplexDropDown.Store;

public interface ILargeComplexObjectService
{
    Task<IList<LargeComplexObject>> GetComplexObjectsAsync(DateTime? selectedDate);
}