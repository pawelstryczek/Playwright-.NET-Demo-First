using Microsoft.Playwright;

namespace TheInternetPage.PageObject
{
    public class LoginPage
    {
        private readonly IPage _page;
        private ILocator _header => _page.Locator("//h2[text()='Login Page']");
		private ILocator _userNameInput => _page.Locator("input[id='username']");
		private ILocator _passwordInput => _page.Locator("input[id='password']");
		private ILocator _loginButton => _page.Locator("button[type='submit']");
		public LoginPage(IPage page) 
        {
            _page = page;             
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