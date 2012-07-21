namespace Ffsti.MeetingRoom.Service.Validation
{
    public interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        bool IsValid();
    }
}
