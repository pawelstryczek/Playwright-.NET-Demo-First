using Microsoft.Playwright;

namespace TheInternetPage.PageObject
{
    public class CheckboxesPage
    {
        private readonly IPage _page;
        private ILocator Header => _page.Locator("//h3[text()='Checkboxes']");
        private ILocator Checkboxes => _page.Locator("input");

        public CheckboxesPage(IPage page)
        {
            _page = page;
            Header.WaitForAsync(new() { State = WaitForSelectorState.Visible }).Wait();
        }

        public CheckboxesPage SelectCheckboxOne()
        {
            Checkboxes.Nth(0).CheckAsync().Wait();
            return this;
        }
        public CheckboxesPage UnSelectCheckboxTwo()
        {
            Checkboxes.Nth(1).UncheckAsync().Wait();
            return this;
        }

        public bool IsCheckBoxOneSelected()
        {
            return Checkboxes.Nth(0).IsCheckedAsync().Result;
        }
        public bool IsCheckBoxTwoSelected()
        {
            return Checkboxes.Nth(1).IsCheckedAsync().Result;
        }
    }
}
