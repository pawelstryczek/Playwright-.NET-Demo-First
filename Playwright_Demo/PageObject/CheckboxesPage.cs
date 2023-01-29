using Microsoft.Playwright;

namespace TheInternetPage.PageObject
{
    internal class CheckboxesPage
    {
        private readonly IPage _page;
        private readonly ILocator _header;
        private readonly ILocator _checkboxes;

        public CheckboxesPage(IPage page)
        {
            _page = page;
            _header = page.Locator("//h3[text()='Checkboxes']");
            _checkboxes = page.Locator("input");
            _header.WaitForAsync(new() { State = WaitForSelectorState.Visible }).Wait();
        }

        public CheckboxesPage SelectCheckboxOne()
        {
            _checkboxes.Nth(0).CheckAsync().Wait();
            return this;
        }
        public CheckboxesPage UnSelectCheckboxTwo()
        {
            _checkboxes.Nth(1).UncheckAsync().Wait();
            return this;
        }

        public bool IsCheckBoxOneSelected()
        {
            return _checkboxes.Nth(0).IsCheckedAsync().Result;
        }
        public bool IsCheckBoxTwoSelected()
        {
            return _checkboxes.Nth(1).IsCheckedAsync().Result;
        }
    }
}
