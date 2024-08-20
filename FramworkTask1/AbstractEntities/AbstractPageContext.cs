
namespace FramworkTask1.AbstractEntities
{
    abstract class AbstractPageContext : AbstractPage
    {
        public T VerifyPageUerl<T>(string expectedUrl) where T : class
        {
            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl), $"Urls are not equals, expected was: [{expectedUrl}], but actual: [{actualUrl}]");
            try
            {
                return Activator.CreateInstance(typeof(T), driver) as T;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something hepend with returning type! \n Exeption: {ex}");
            }
        }
    }
}
