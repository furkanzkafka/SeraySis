
namespace SeraySis.Entities.Messages
{
    public enum ErrorMessageCode
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExists = 102,

        UserIsNoActive = 203,
        UserNameOrPassWrong = 204,

        CheckYourEmail = 303,
        UserAlreadyActive = 304,
        UserNotFound = 305,
        ActivateIdDoesNotExists = 306,
        ProfileCouldNotUpdated = 307
    }
}
