using Microsoft.Playwright;

namespace TheInternetPage.PageObject
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator _header;
        private readonly ILocator _userNameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _loginButton;
        public LoginPage(IPage page) 
        {
            _page = page;
            _header = page.Locator("//h2[text()='Login Page']");
            _userNameInput = page.Locator("input[id='username']");
            _passwordInput = page.Locator("input[id='password']");
            _loginButton = page.Locator("button[type='submit']");
            _header.WaitForAsync(new() { State = WaitForSelectorState.Visible }).Wait();
        }

        public LoginPage EnterUsername(string username)
        {            
            _userNameInput.FillAsync(username).Wait();
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            _passwordInput.FillAsync(password).Wait();
            return this;
        }

        public SecureAreaPage ClickLogin()
        {
            _loginButton.ClickAsync().Wait();
            return new(_page);
        }




    }
}