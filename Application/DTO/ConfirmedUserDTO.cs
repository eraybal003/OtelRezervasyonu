namespace Application.DTO;

public class ConfirmedUserDTO
{
    public string UserID { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public ConfirmedUserDTO()
    {

    }
    public ConfirmedUserDTO(string UserId, string token)
    {
        UserID = UserId;
        Token = token;
    }
}