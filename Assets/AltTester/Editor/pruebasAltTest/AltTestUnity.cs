using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;
using UnityEngine;

public class TestAltUnity
{
    private AltDriver altDriver;

    [OneTimeSetUp]
    public void SetUp()
    {
        System.Threading.Thread.Sleep(3000);
        altDriver = new AltDriver();

    }

    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }

    [Test]
    public void TestStartButtonIsVisible()
    {
        altDriver.WaitForCurrentSceneToBe("Main");
        var a = altDriver.WaitForObject(By.NAME, "StartButton");
        Assert.IsTrue(a.enabled);
    }

    [Test]
    public void TestModelIsActive()
    {
        altDriver.LoadScene("Main");
        var a = altDriver.WaitForObject(By.NAME, "character(Clone)");

        Assert.IsTrue(a.enabled);
    }

}