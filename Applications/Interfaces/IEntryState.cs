namespace RiwiEmplea.Applications.Interfaces
{
  /*
    IEntryState allow us to check if a model entry status it could be

      * Update
      * Delete
      * Add
    
    To know what action to follow
  */
  public interface IEntryState<T>
  {
    bool ExistEntryInDb(T model);
  }
}