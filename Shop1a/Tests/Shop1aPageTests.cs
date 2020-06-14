using NUnit.Framework;


namespace Shop1a.Tests
{
    public class Shop1aPageTests : TestBase
    {

        [Test]
        public static void SearchItemTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .EnterKeywordToSearchBox("džiovintuvas")
                .ClickMainSeachButton()
                .ClickHairDryerCheckBox()
                .CheckResultHeading("Plaukų džiovintuvai");
        }

        [Test]
        public static void CheckGoingToSignUpPageTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .GoToSignUpPage("Registruotis")
                .CheckIfWeAreOnRegistrationPage("Registruokitės");
        }

        [Test]
        public static void CheckGoingToSignInPageTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .GoToSignInPage("Prisijungti")
                .CheckIfWeAreOnSignInPage("Prisijungti");
        }

        [Test]
        public static void RegistrationTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .GoToSignUpPage("Registruotis")
                .PerformSignUp("gktest321654@gmail.com", "Test3210", "Test3210")
                .CheckErrorMessageAfterReregistration("toks el. pašto adresas jau užimtas");
        }

        [Test]
        public static void SignInTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .GoToSignInPage("Prisijungti")
                .PerformSignIn("gktest321654@gmail.com", "Test3210")
                .CheckAfterSignIn("Mano profilis");
        }

        [Test]
        public static void AddingItemToCartTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .GoToComputerEquipmentPage()
                .SelectLaptopsAndAccesoriesCategory()
                .SelectLaptopsCategory()
                .SelectLaptopsForBusinessCategory()
                .EnterPriceLimits(600, 2000)
                .ChooseComputerBrand()
                .SortResultsByPriceAscending()
                .AddToChartFirstProductItem()
                .GoToShoppingCartPage()
                .CheckIfWeAreOnShoppingCartPage("Pirkinių krepšelis");
        }

        [Test]
        public static void CheckItemPriceTest()
        {
            _shop1AMainPage
                .OpenShop1aPage()
                .AddCookieConcent()
                .GoToComputerEquipmentPage()
                .SelectLaptopsAndAccesoriesCategory()
                .SelectLaptopsCategory()
                .SelectLaptopsForBusinessCategory()
                .EnterPriceLimits(600, 2000)
                .ChooseComputerBrand()
                .SortResultsByPriceAscending()
                .ComparePrices(600);
        }


    }
}
