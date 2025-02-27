namespace EnterpriseAppFluxor.Features.Dropdowns.Store;

public interface IComplexObjectService
{
    Task<IEnumerable<ComplexObject>> GetComplexObjectsAsync();
}