using Microsoft.Playwright;

namespace TheInternetPage.PageObject
{
    public class SecureAreaPage
    {
        private readonly IPage _page;
        private ILocator _header => _page.Locator("//h2[contains(text(),'Secure Area')]");
		private ILocator _status => _page.Locator("div[id='flash']");

		public SecureAreaPage(IPage page) 
        {
            _page = page;             
            _header.WaitForAsync(new() { State = WaitForSelectorState.Visible }).Wait();
        }

        public string GetLoginStatus()
        {
            return _status.InnerTextAsync().Result;
        }
    }
}