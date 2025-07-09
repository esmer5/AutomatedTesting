
public abstract class LoginHandler
{
    protected LoginHandler _next;

    public void SetNext(LoginHandler next)
    {
        _next = next;
    }

    public abstract string Handle(string username, string password);
}

public class UsernameRequiredHandler : LoginHandler
{
    public override string Handle(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
            return "Epic sadface: Username is required";

        return _next?.Handle(username, password);
    }
}

public class PasswordRequiredHandler : LoginHandler
{
    public override string Handle(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return "Epic sadface: Password is required";

        return _next?.Handle(username, password);
    }
}
